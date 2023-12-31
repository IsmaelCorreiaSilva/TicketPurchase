
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketPurchase.Core.Entities;

namespace TicketPurchase.Infra.Data.Mappings
{

    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.CreateAt).IsRequired();
        }
    }
}
