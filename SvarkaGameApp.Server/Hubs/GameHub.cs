using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace SvarkaGameApp.Server.Hubs
{
    

    public class GameHub : Hub
    {
        public async Task SendMove(string user, string cardPlayed)
        {
            await Clients.All.SendAsync("ReceiveMove", user, cardPlayed);
        }

        public async Task JoinGame(string gameId, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).SendAsync("UserJoined", user);
        }
    }

}
