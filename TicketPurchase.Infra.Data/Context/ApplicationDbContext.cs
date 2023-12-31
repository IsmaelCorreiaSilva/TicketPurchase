using Microsoft.EntityFrameworkCore;
using TicketPurchase.Core.Entities;
using TicketPurchase.Infra.Data.Mappings;

namespace TicketPurchase.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventMap());
        }
    }
}
