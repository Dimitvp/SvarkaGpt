using SvarkaGameApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvarkaGameApp.Shared.Interfaces
{
    interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(int cardId);
    }
}
