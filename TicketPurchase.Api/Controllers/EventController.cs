using Microsoft.AspNetCore.Mvc;
using TicketPurchase.Application.Interfaces;
using TicketPurchase.Application.Models.Event;

namespace TicketPurchase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await eventService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventCreateModel newEvent)
        {
            await eventService.InsertAsync(newEvent);
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(EventUpdateModel updateEvent)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
