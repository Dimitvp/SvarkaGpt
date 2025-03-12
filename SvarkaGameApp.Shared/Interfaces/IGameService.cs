namespace SvarkaGameApp.Shared.Interfaces
{
    public interface IGameService
    {
        Task StartGameAsync(string lobbyId);
        Task JoinGameAsync(string gameId, string playerId);
        Task PlayCardAsync(string gameId, string playerId, int cardId);
    }
}
