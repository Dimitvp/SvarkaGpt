using Microsoft.AspNetCore.Mvc;
using SvarkaGameApp.Server.Services;
using SvarkaGameApp.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using SvarkaGameApp.Shared.Interfaces;

namespace SvarkaGameApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyService _lobbyService;

        public LobbyController(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        // Create a new lobby
        [HttpPost("create")]
        public async Task<IActionResult> CreateLobby([FromBody] string hostPlayer)
        {
            var lobby = await _lobbyService.CreateLobbyAsync(hostPlayer);
            if (lobby == null)
                return BadRequest("Could not create lobby.");
            return Ok(lobby);
        }

        // Join an existing lobby
        [HttpPost("join")]
        public async Task<IActionResult> JoinLobby([FromBody] LobbyJoinRequest request)
        {
            var result = await _lobbyService.JoinLobbyAsync(request.LobbyId, request.PlayerName);
            if (!result)
                return BadRequest("Could not join lobby.");
            return Ok();
        }

        // Get all active lobbies
        [HttpGet("all")]
        public async Task<ActionResult<List<LobbyModel>>> GetAllLobbies()
        {
            var lobbies = await _lobbyService.GetAllLobbiesAsync();
            return Ok(lobbies);
        }
    }
}
