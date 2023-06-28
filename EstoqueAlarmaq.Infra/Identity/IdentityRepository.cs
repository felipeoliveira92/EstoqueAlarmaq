using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;

        public IdentityRepository(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure)
            => await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure);

        public async Task Logout() 
            => await _signInManager.SignOutAsync();
        
        public async Task<string> GenerateTokenByUserAsync(UserModel user)
            => await _userManager.GenerateEmailConfirmationTokenAsync(user);

        public async Task<bool> IsEmailConfirmedAsync(UserModel user)
            => await _userManager.IsEmailConfirmedAsync(user);

        public async Task<UserModel> FindUserByEmailAsync(string email)
            => (UserModel)await _userManager.FindByEmailAsync(email);

        public async Task<string> GeneratePasswordResetTokenAsync(UserModel user)
            => await _userManager.GeneratePasswordResetTokenAsync(user);
    }
}
