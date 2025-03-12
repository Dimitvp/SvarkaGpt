using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SvarkaGameApp.Shared.Models
{
    public class TableModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public List<LobbyPlayer> Players { get; set; } = new();
        public TableStatus Status { get; set; } = TableStatus.Waiting;
        public string CreatorId { get; set; }  // ID of the player who created the table
    }

    public enum TableStatus
    {
        Waiting,
        InProgress,
        Finished
    }
}
