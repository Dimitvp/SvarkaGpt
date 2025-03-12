using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Interfaces
    {
        

        public interface ICardRepository
        {
            Task<Card> GetCardByIdAsync(int cardId);
            Task<List<Card>> GetAllCardsAsync();
            Task AddCardAsync(Card card);
            Task UpdateCardAsync(Card card);
            Task DeleteCardAsync(int cardId);
        }
    }

