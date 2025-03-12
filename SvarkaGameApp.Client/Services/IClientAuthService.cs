using System.Threading.Tasks;

namespace SvarkaGameApp.Client.Services
{
    public interface IClientAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<bool> IsUserAuthenticated();
        Task<string?> GetUserDisplayName();
    }
}
