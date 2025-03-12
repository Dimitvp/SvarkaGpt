using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        // DbSets for all the models
        public DbSet<Score> Scores { get; set; }
        public DbSet<LobbyModel> Lobbies { get; set; }
        public DbSet<LobbyPlayer> LobbyPlayers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<PlayerState> PlayerStates { get; set; }
        public DbSet<TableModel> Tables { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure GameState and PlayerState relationships
            modelBuilder.Entity<GameState>()
                .HasMany(gs => gs.Players)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            // Disable cascade delete for Cards to avoid multiple cascade paths
            modelBuilder.Entity<GameState>()
                .HasMany(gs => gs.PlayedCards)
                .WithOne()
                .HasForeignKey("PlayedCardsForeignKey")
                .OnDelete(DeleteBehavior.NoAction);  // Changed to NoAction

            modelBuilder.Entity<GameState>()
                .HasMany(gs => gs.Deck)
                .WithOne()
                .HasForeignKey("DeckForeignKey")
                .OnDelete(DeleteBehavior.NoAction);  // Changed to NoAction

            // Example for PlayerState if you need it
            modelBuilder.Entity<PlayerState>()
                .HasMany(ps => ps.Hand)
                .WithOne()
                .HasForeignKey("HandForeignKey")
                .OnDelete(DeleteBehavior.NoAction);  // Changed to NoAction

            modelBuilder.Entity<TableModel>()
               .HasMany(t => t.Players)
               .WithOne()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
