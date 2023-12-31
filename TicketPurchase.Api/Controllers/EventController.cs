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
        public async Task<ActionResult> Get(Guid id)
        {
            var searchedEvent = await eventService.GetByIdAsync(id);

            if(searchedEvent == null)
               return NotFound();

            return Ok(searchedEvent);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventCreateModel newEvent)
        {
            var eventCreated = await eventService.InsertAsync(newEvent);
            return CreatedAtAction(nameof(Get), new { id = eventCreated.Id }, eventCreated);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EventUpdateModel updateEvent)
        {
            var resultEvent = await eventService.UpdateAsync(updateEvent);
            
            if (resultEvent == null)
                return NotFound();

            return Ok(resultEvent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var searchedEvent = await eventService.GetByIdAsync(id);

            if(searchedEvent == null)
                return NotFound();

            await eventService.DeleteAsync(id);

            return NoContent();
        }
    }
}
