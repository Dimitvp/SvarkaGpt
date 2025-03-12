using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGameByIdAsync(string gameId);
        Task<List<Game>> GetAllGamesAsync();
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
    }
}
