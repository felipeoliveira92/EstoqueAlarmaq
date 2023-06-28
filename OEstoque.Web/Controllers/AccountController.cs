using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OEstoque.Web.Models;

namespace OEstoque.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserApplication _userRepository;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager,
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Não foi possivel validar email!");
            }

            return View();
        }

        #region ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.Users.AsNoTracking().Any(u => u.NormalizedEmail == model.Email.ToUpper().Trim()))
                {
                    var user = await _userRepository.FindUserByEmailAsync(model.Email);
                    var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
                    var urlConfirmation = Url.Action(nameof(ResetPassword), "Account", new { token }, Request.Scheme);

                    _userRepository.GenerateForgotPasswordEmail(user, urlConfirmation);

                    return View(nameof(SentResetPassword));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Usuário/e-mail <b>{model.Email}</b> não encontrado.");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult SentResetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            var model = new ResetPasswordViewModel
            {
                Token = token,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(model.Email);
                var resultado = await _userManager.ResetPasswordAsync(
                    usuario, model.Token, model.NewPassword);
                if (resultado.Succeeded)
                {
                    //this.MostrarMensagem(
                    //   $"Senha redefinida com sucesso! Agora você já pode fazer login com a nova senha.");
                    return View(nameof(Login));
                }
                else
                {
                    //this.MostrarMensagem(
                    //    $"Não foi possível redefinir a senha. Verifique se preencheu a senha corretamente. Se o problema persistir, entre em contato com o suporte.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        #endregion
    }
}
