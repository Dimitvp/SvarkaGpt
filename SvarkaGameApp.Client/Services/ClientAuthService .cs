using SvarkaGameApp.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace SvarkaGameApp.Client.Services
{
    public class ClientAuthService : IClientAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenStorage _tokenStorage;
        private readonly NavigationManager _navigation;

        public ClientAuthService(HttpClient httpClient, TokenStorage tokenStorage, NavigationManager navigation)
        {
            _httpClient = httpClient;
            _tokenStorage = tokenStorage;
            _navigation = navigation;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", new LoginModel { Email = email, Password = password });
            if (!response.IsSuccessStatusCode)
                return false;

            var token = await response.Content.ReadAsStringAsync();
            await _tokenStorage.SaveTokenAsync(token);

            // Set the Authorization header for future requests
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return true;
        }

        public async Task LogoutAsync()
        {
            await _tokenStorage.RemoveTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _navigation.NavigateTo("/login", forceLoad: true);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var token = await _tokenStorage.GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public async Task<string> GetUserDisplayName()
        {
            var token = await _tokenStorage.GetTokenAsync();
            return string.IsNullOrEmpty(token) ? "Guest" : "User"; // Simplified for now
        }
    }
}
