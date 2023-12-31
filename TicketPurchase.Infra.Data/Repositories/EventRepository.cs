
using Microsoft.EntityFrameworkCore;
using TicketPurchase.Core.Entities;
using TicketPurchase.Core.Interfaces;
using TicketPurchase.Infra.Data.Context;
using TicketPurchase.Infra.Data.Expeptions;

namespace TicketPurchase.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext context;

        public EventRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await context.Events.FindAsync(id);
            if (result != null)
            {
                context.Events.Remove(result);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            if (id != Guid.Empty)
                return await context.Events.FindAsync(id);

            throw new RepositoryException("O ID informado não existe ou está vázio!");
        }

        public async Task<Event> InsertAsync(Event newEvent)
        {
            if (newEvent != null)
            {
                context.AddAsync(newEvent);
                await context.SaveChangesAsync();
                return newEvent;
            }
            throw new RepositoryException("Erro ao tentar salvar os dados!");
        }

        public async Task<Event> UpdateAsync(Event updateEvent)
        {
            if(updateEvent != null)
            {
                var result = await context.Events.FindAsync(updateEvent.Id);
                if(result != null)
                {
                    context.Entry(result).CurrentValues.SetValues(updateEvent);
                    await context.SaveChangesAsync();
                    return updateEvent;
                }
            }
            return null;
        }
    }
}
