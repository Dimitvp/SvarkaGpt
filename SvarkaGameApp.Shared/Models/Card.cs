using System.ComponentModel.DataAnnotations;

namespace SvarkaGameApp.Shared.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Points { get; set; }
        public bool IsWild { get; set; } = false;  // Wild card indicator
    }


}
