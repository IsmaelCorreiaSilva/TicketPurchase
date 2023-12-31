
namespace TicketPurchase.Application.Models.Event
{
    public class EventCreateModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int NumberVacancies { get; set; }
    }
}
