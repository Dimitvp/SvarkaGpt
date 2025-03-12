using Microsoft.AspNetCore.Cors.Infrastructure;
using SvarkaGameApp.Server.Data;
using SvarkaGameApp.Shared.Models;
using SvarkaGameApp.Shared.Interfaces;

namespace SvarkaGameApp.Server.Services
{
    public class ScoreService : IScoreService
    {
        private readonly AppDbContext _context;

        public ScoreService(AppDbContext context)
        {
            _context = context;
        }

        public Task<int> GetScoreAsync(string playerId)
        {
            throw new NotImplementedException();
        }

        public List<Score> GetScores() => _context.Scores.OrderByDescending(s => s.Points).ToList();

        public void UpdateScore(string player, int points)
        {
            var score = _context.Scores.FirstOrDefault(s => s.Username == player);
            if (score != null)
            {
                score.Points += points;
            }
            else
            {
                _context.Scores.Add(new Score { Username = player, Points = points });
            }
            _context.SaveChanges();
        }

        public Task UpdateScoreAsync(string playerId, int points)
        {
            throw new NotImplementedException();
        }
    }

}
