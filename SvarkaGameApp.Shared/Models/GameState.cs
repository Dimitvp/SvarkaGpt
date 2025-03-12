using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SvarkaGameApp.Shared.Models
{
    public class GameState
    {
        [Key]
        public int GameId { get; set; }                     // Primary Key (was already in place)
        public List<PlayerState> Players { get; set; }       // Current state of each player
        public List<Card> PlayedCards { get; set; }          // Cards played in current round
        public string CurrentTurn { get; set; }              // Username of the current player
        public string Status { get; set; }                   // Game status (e.g., Waiting, InProgress, Finished)
        public int Round { get; set; }                       // Current round number
        public List<Card> Deck { get; set; }                 // Remaining cards in the deck

        // Constructor to initialize lists
        public GameState()
        {
            Players = new List<PlayerState>();
            PlayedCards = new List<Card>();
            Deck = new List<Card>();
        }
    }
}
