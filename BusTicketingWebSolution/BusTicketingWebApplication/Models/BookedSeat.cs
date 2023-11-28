namespace BusTicketingWebApplication.Models
{
    public class BookedSeat
    {
        public int Id { get; set; }
        public List<int> BookedSeats { get; set; }
        public int BusId { get; set; }
    }
}
