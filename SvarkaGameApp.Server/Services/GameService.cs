using SvarkaGameApp.Server.Data;
using SvarkaGameApp.Server.Interfaces;
using SvarkaGameApp.Shared.Interfaces;
using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICardRepository _cardRepository;

        public GameService(IGameRepository gameRepository, ICardRepository cardRepository)
        {
            _gameRepository = gameRepository;
            _cardRepository = cardRepository;
        }

        public void DealCards(Game game)
        {
            var deck = GenerateDeck();
            var random = new Random();
            var shuffledDeck = deck.OrderBy(x => random.Next()).ToList();

            int playerCount = game.Players.Count;
            for (int i = 0; i < playerCount; i++)
            {
                var playerCards = shuffledDeck.Skip(i * 10).Take(10).ToList();
                // Save cards to the database or return to the client
            }
        }

        public bool IsValidMove(Card playedCard, Card leadCard, bool isTrump)
        {
            if (playedCard.IsWild)
            {
                // Wild card can act as any suit
                return true;
            }

            // Follow suit if possible, else play a trump card
            return playedCard.Suit == leadCard.Suit || isTrump;
        }

        public Task JoinGameAsync(string gameId, string playerId)
        {
            throw new NotImplementedException();
        }

        public Task PlayCardAsync(string gameId, string playerId, int cardId)
        {
            throw new NotImplementedException();
        }

        public Task StartGameAsync(string lobbyId)
        {
            throw new NotImplementedException();
        }

        private List<Card> GenerateDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "7", "8", "9", "10", "J", "Q", "K", "A" };
            var values = new[] { 0, 0, 0, 10, 2, 3, 4, 11 };

            var deck = new List<Card>();
            foreach (var suit in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    // Check for 7 of Clubs as a wild card
                    if (suit == "Clubs" && ranks[i] == "7")
                    {
                        deck.Add(new Card
                        {
                            Suit = suit,
                            Rank = ranks[i],
                            Points = 11,
                            IsWild = true  // Custom property to mark wild cards
                        });
                    }
                    else
                    {
                        deck.Add(new Card
                        {
                            Suit = suit,
                            Rank = ranks[i],
                            Points = values[i],
                            IsWild = false  // Normal cards
                        });
                    }
                }
            }
            return deck;
        }

    }

}
