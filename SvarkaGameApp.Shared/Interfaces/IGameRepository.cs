using SvarkaGameApp.Shared.Models;
namespace SvarkaGameApp.Shared.Interfaces
{
    interface IGameRepository
    {
        Task<Game?> GetGameByIdAsync(string gameId);
        Task SaveGameAsync(Game game);
    }
}
