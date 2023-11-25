namespace BusTicketingWebApplication.Models.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusId { get; set; }
        public string Date { get; set; }
        public int NoOfSeats { get; set; }
    }
}
