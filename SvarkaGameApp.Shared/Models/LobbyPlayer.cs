using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SvarkaGameApp.Shared.Models
{
    public class LobbyPlayer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key to Lobby
        public string LobbyId { get; set; }
        public LobbyModel Lobby { get; set; }
    }
}
