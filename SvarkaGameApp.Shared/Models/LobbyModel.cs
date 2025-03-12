using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SvarkaGameApp.Shared.Models
{
    public class LobbyModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public List<LobbyPlayer> Players { get; set; } = new();
        public LobbyStatus Status { get; set; } = LobbyStatus.Waiting;
    }

    public enum LobbyStatus
    {
        Waiting,
        InProgress,
        Finished
    }
}
