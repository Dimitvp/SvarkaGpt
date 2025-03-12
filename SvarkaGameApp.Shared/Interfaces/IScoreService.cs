namespace SvarkaGameApp.Shared.Interfaces
{
    public interface IScoreService
    {
        Task<int> GetScoreAsync(string playerId);
        Task UpdateScoreAsync(string playerId, int points);
    }
}
