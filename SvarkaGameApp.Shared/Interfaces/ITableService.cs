using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Shared.Interfaces
{
    public interface ITableService
    {
        Task<List<TableModel>> GetAllTablesAsync();
        Task<TableModel> CreateTableAsync(string name, bool isPrivate);
        Task<bool> JoinTableAsync(string tableId, string playerName);
    }
}
