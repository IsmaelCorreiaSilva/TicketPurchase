using AutoMapper;
using TicketPurchase.Application.Interfaces;
using TicketPurchase.Application.Models.Event;
using TicketPurchase.Core.Entities;
using TicketPurchase.Core.Interfaces;

namespace TicketPurchase.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
           return eventRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EventViewModel>> GetAllAsync()
        {
            var listEvents = await eventRepository.GetAllAsync();
            return mapper.Map<IEnumerable<EventViewModel>>(listEvents);
        }

        public async Task<EventViewModel> GetByIdAsync(Guid id)
        {
            var searchEvent = await eventRepository.GetByIdAsync(id);
            return mapper.Map<EventViewModel>(searchEvent);
        }

        public async Task<EventViewModel> InsertAsync(EventCreateModel newEvent)
        {
            var eventCreate = mapper.Map<Event>(newEvent);
            var resultCreate = await eventRepository.InsertAsync(eventCreate);
            return mapper.Map<EventViewModel>(resultCreate);
        }

        public async Task<EventViewModel> UpdateAsync(EventUpdateModel updateEvent)
        {
            var eventUpdate  =  mapper.Map<Event>(updateEvent);
            var resultUpdade = await eventRepository.UpdateAsync(eventUpdate);
            return mapper.Map<EventViewModel>(resultUpdade);

        }
    }
}
