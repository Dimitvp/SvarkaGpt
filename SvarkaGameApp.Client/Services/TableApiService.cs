using SvarkaGameApp.Shared.Interfaces;
using SvarkaGameApp.Shared.Models;
using System.Net.Http.Json;

namespace SvarkaGameApp.Client.Services
{
    public class TableApiService : ITableService
    {
        private readonly HttpClient _httpClient;

        public TableApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TableModel>> GetAllTablesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TableModel>>("api/tables");
        }

        public async Task<TableModel> CreateTableAsync(string tableName, bool isPrivate)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tables", new { Name = tableName, IsPrivate = isPrivate });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TableModel>();
        }

        public async Task<bool> JoinTableAsync(string tableId, string playerName)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/tables/{tableId}/join", playerName);
            return response.IsSuccessStatusCode;
        }
    }
}
