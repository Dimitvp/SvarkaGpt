namespace SvarkaGameApp.Shared.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }       
        public string CurrentTurn { get; set; }  
        public List<Card> Deck { get; set; }     
        public List<User> Players { get; set; }  
        public GameState State { get; set; }     
    }

}
