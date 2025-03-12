using Microsoft.AspNetCore.SignalR;
using SvarkaGameApp.Shared.Models;


namespace SvarkaGameApp.Server.Hubs
{

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdateGameState(GameState state)
        {
            await Clients.All.SendAsync("ReceiveGameState", state);
        }

    }

}
