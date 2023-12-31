
namespace TicketPurchase.Core.Entities
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public string Duration { get; private set; }
        public string Description { get; private set; }
        public int NumberVacancies { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
    }
}
