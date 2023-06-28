using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Identity
{
    public interface IIdentityRepository
    {
        Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task Logout();
        Task<string> GenerateTokenByUserAsync(UserModel user);
        Task<bool> IsEmailConfirmedAsync(UserModel user);
        Task<UserModel> FindUserByEmailAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(UserModel user);
    }
}
