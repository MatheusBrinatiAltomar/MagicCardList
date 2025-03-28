using MagicCardInfo.Domain.Models;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Infrastructure.Models;

namespace MagicCardInfo.Infrastructure.Persistance
{
    public class CardRepositry : ICardRepository
    {
        private readonly ApplicationDbContext _context;
        public async Task UpsertCardsAsync(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                var existingCard = await _context.Cards.FindAsync(card.Id);
                if (existingCard == null)
                    _context.Cards.Add(card);
                else
                    _context.Cards.Update(card);
            }
            await _context.SaveChangesAsync();
        }
    }
}