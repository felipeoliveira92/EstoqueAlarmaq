using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Identity;
using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using OEstoque.Web.Models;
using System.Text;

namespace OEstoque.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IIdentityRepository _identityRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            IIdentityRepository identityRepository, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityRepository = identityRepository;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser {                    
                    UserName = model.Email, 
                    Email = model.Email 
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    role.NormalizedName = "ADMIN";
                    role.ConcurrencyStamp = Guid.NewGuid().ToString();

                    var roleResult = await _roleManager.CreateAsync(role);

                }

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");

                    await GenerateConfirmEmail(user);

                    return View("~/Views/Account/ConfirmEmail.cshtml");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (!_userManager.IsEmailConfirmedAsync(user).Result)
                {
                    ModelState.AddModelError(string.Empty, "Email ainda não confirmado");
                    return View(model);
                }

                var result = await _identityRepository.Login(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);                

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _identityRepository.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }
        
        private async Task GenerateConfirmEmail(IdentityUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlConfirmacao = Url.Action("ConfirmEmail",
                "Account", new { mail = user.Email, token }, Request.Scheme);
            var mensagem = new StringBuilder();
            mensagem.Append($"<p>Olá, {user.UserName}.</p>");
            mensagem.Append("<p>Recebemos seu cadastro em nosso sistema. Para concluir o processo de cadastro, clique no link a seguir:</p>");
            mensagem.Append($"<p><a href='{urlConfirmacao}'>Confirmar Cadastro</a></p>");
            mensagem.Append("<p>Atenciosamente,<br>Equipe de Suporte</p>");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string mail, string token)
        {
            var user = await _userManager.FindByEmailAsync(mail);

            if (user == null)
                ModelState.AddModelError(string.Empty, "Usuário não encontrado!");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Não foi possivel validar email!");
            }

            return View();
        }
    }
}
