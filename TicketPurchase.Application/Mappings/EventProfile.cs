
using AutoMapper;
using TicketPurchase.Application.Models.Event;
using TicketPurchase.Core.Entities;

namespace TicketPurchase.Application.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventCreateModel, Event>()
                .ForMember(c => c.CreateAt, o => o.MapFrom(_ => DateTime.Now));
            CreateMap<EventUpdateModel, Event>()
                .ForMember(c => c.UpdateAt, o => o.MapFrom(_ => DateTime.Now));
            CreateMap<Event, EventViewModel>();
        }
    }
}
