using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SvarkaGameApp.Shared.Models
{
    // Represents the state of a single player
    public class PlayerState
    {
        [Key]
        public int Id { get; set; }                          // Primary Key (newly added)
        public string Username { get; set; }                 // Username of the player
        public List<Card> Hand { get; set; }                 // Cards currently in player's hand
        public int Score { get; set; }                       // Player's current score

        // Constructor to initialize lists
        public PlayerState()
        {
            Hand = new List<Card>();
        }
    }
}

