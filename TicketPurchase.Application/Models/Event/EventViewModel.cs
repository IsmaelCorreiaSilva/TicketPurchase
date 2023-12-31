
namespace TicketPurchase.Application.Models.Event
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public int NumberVacancies { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
