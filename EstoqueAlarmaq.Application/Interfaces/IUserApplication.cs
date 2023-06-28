using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task Logout();
        void GenerateConfirmationEmail(UserModel user, string urlConfirmation);
        Task<bool> IsEmailConfirmedAsync(UserModel user);
        Task<UserModel> FindUserByEmailAsync(string email);
        Task<string> GenerateTokenByUserAsync(UserModel user);
        Task<string> GeneratePasswordResetTokenAsync(UserModel user);
        void GenerateForgotPasswordEmail(UserModel user, string urlConfirmation);
    }
}
