
using TicketPurchase.Application.Models.Event;

namespace TicketPurchase.Application.Interfaces
{
    public interface IEventService
    {
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<EventViewModel>> GetAllAsync();
        Task<EventViewModel> GetByIdAsync(Guid id);
        Task<EventViewModel> InsertAsync(EventCreateModel newEvent);
        Task<EventViewModel> UpdateAsync(EventUpdateModel updateEvent);
    }
}
