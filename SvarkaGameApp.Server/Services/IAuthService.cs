namespace SvarkaGameApp.Server.Services
{
    using Microsoft.AspNetCore.Identity;
    using SvarkaGameApp.Shared.Models;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterModel model);
        Task<string?> LoginAsync(LoginModel model);
    }
}
