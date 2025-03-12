using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Check if any Lobbies exist
            if (!context.Lobbies.Any())
            {
                context.Lobbies.AddRange(new List<LobbyModel>
                {
                    new LobbyModel { Name = "Test Lobby 1", Status = LobbyStatus.Waiting },
                    new LobbyModel { Name = "Test Lobby 2", Status = LobbyStatus.InProgress }
                });
                context.SaveChanges();
            }

            // Check if any Users exist
            if (!context.Users.Any())
            {
                context.Users.Add(new User { UserName = "testuser", Email = "test@example.com", DisplayName = "testuser" });
                context.SaveChanges();
            }
        }
    }
}
