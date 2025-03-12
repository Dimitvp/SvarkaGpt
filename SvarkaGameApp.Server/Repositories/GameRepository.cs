using Microsoft.EntityFrameworkCore;
using SvarkaGameApp.Server.Data;
using SvarkaGameApp.Server.Interfaces;
using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game> GetGameByIdAsync(string gameId) => await _context.Games.Include(g => g.Players).FirstOrDefaultAsync(g => g.Id == gameId);

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
