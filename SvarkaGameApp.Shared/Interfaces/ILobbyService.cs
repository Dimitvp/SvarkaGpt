using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Shared.Interfaces
{
    public interface ILobbyService
    {
        Task<List<LobbyModel>> GetAllLobbiesAsync();
        Task<LobbyModel> CreateLobbyAsync(string hostPlayerName);
        Task<bool> JoinLobbyAsync(string lobbyId, string playerName);
    }
}
