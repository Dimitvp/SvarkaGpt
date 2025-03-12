using SvarkaGameApp.Server.Data;
using SvarkaGameApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using SvarkaGameApp.Shared.Interfaces;

namespace SvarkaGameApp.Server.Services
{
    public class LobbyService : ILobbyService
    {
        private readonly AppDbContext _dbContext;

        private readonly ITableService _tableService;

        public LobbyService(AppDbContext dbContext, ITableService tableService)
        {
            _dbContext = dbContext;
            _tableService = tableService;
        }


        public async Task<List<LobbyModel>> GetAllLobbiesAsync()
        {
            return await _dbContext.Lobbies.Include(l => l.Players).ToListAsync();
        }

        public async Task<LobbyModel> CreateLobbyAsync(string hostPlayerName)
        {
            var newLobby = new LobbyModel();
            newLobby.Players.Add(new LobbyPlayer { Name = hostPlayerName });
            _dbContext.Lobbies.Add(newLobby);
            await _dbContext.SaveChangesAsync();
            return newLobby;
        }

        public async Task<bool> JoinLobbyAsync(string lobbyId, string playerName)
        {
            var lobby = await _dbContext.Lobbies.Include(l => l.Players).FirstOrDefaultAsync(l => l.Id == lobbyId);
            if (lobby == null || lobby.Players.Count >= 4)  // Assuming max 4 players
                return false;

            lobby.Players.Add(new LobbyPlayer { Name = playerName });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TableModel>> GetAllTablesAsync()
        {
            return await _tableService.GetAllTablesAsync();
        }

        public async Task<TableModel> CreateTableAsync(string name, bool isPrivate)
        {
            return await _tableService.CreateTableAsync(name, isPrivate);
        }

        public async Task<bool> JoinTableAsync(string tableId, string playerName)
        {
            return await _tableService.JoinTableAsync(tableId, playerName);
        }


    }
}
