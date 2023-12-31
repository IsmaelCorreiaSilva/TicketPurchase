
using TicketPurchase.Core.Entities;

namespace TicketPurchase.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(Guid id);
        Task<Event> InsertAsync(Event newEvent);
        Task<Event> UpdateAsync(Event updateEvent);

    }
}
