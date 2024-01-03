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
        /// <summary>
        /// Retorna a lista de Eventos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await eventService.GetAllAsync());
        }
        /// <summary>
        /// Retorna o Evento buscado por Id
        /// </summary>
        /// <param name="id" exemplo="08dc0a0b-353c-456f-8372-03c7e6326add">Id do Evento</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(Guid id)
        {
            var searchedEvent = await eventService.GetByIdAsync(id);

            if(searchedEvent == null)
               return NotFound();

            return Ok(searchedEvent);
        }
        /// <summary>
        /// Insere um novo Evento
        /// </summary>
        /// <param name="newEvent"></param>
        [HttpPost]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(EventCreateModel newEvent)
        {
            var eventCreated = await eventService.InsertAsync(newEvent);
            return CreatedAtAction(nameof(Get), new { id = eventCreated.Id }, eventCreated);
        }
        /// <summary>
        /// Atualiza um Evento cadastrado
        /// </summary>
        /// <param name="updateEvent"></param>
        [HttpPut]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(EventUpdateModel updateEvent)
        {
            var resultEvent = await eventService.UpdateAsync(updateEvent);
            
            if (resultEvent == null)
                return NotFound();

            return Ok(resultEvent);
        }
        /// <summary>
        /// Excluir um Evento cadastrado
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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
