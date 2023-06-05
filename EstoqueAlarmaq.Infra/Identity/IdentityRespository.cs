using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Identity
{
    public class IdentityRespository : IIdentityRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityRespository(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure);

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
