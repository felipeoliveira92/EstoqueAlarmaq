using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OEstoque.Web.Models;

namespace OEstoque.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserApplication _userRepository;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager, IUserApplication userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
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
                var user = new UserModel {
                    Name = model.Name,
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
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.FindUserByEmailAsync(model.Email);
                if (!await _userRepository.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Email ainda não confirmado!");
                    return View(model);
                }

                var result = await _userRepository.Login(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);                

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");                
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userRepository.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }
        
        private async Task GenerateConfirmEmail(UserModel user)
        {
            var token = await _userRepository.GenerateTokenByUserAsync(user);
            var urlConfirmation = Url.Action("ConfirmEmail", "Account", new { mail = user.Email, token }, Request.Scheme);

            _userRepository.GenerateConfirmationEmail(user, urlConfirmation);
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
