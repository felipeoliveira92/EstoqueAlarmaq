using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Identity
{
    public interface IIdentityRepository
    {
        Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure);
    }
}
