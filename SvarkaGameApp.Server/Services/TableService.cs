using SvarkaGameApp.Server.Data;
using SvarkaGameApp.Shared.Interfaces;
using SvarkaGameApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace SvarkaGameApp.Server.Services
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _dbContext;

        public TableService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TableModel>> GetAllTablesAsync()
        {
            return await _dbContext.Tables.Include(t => t.Players).ToListAsync();
        }

        public async Task<TableModel> CreateTableAsync(string name, bool isPrivate)
        {
            var newTable = new TableModel
            {
                Name = name,
                IsPrivate = isPrivate,
                Status = TableStatus.Waiting
            };
            _dbContext.Tables.Add(newTable);
            await _dbContext.SaveChangesAsync();
            return newTable;
        }

        public async Task<bool> JoinTableAsync(string tableId, string playerName)
        {
            var table = await _dbContext.Tables.Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == tableId);
            if (table == null || table.Players.Count >= 8)
                return false;

            table.Players.Add(new LobbyPlayer { Name = playerName });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
