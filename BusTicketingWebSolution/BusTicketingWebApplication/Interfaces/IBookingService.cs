using BusModelLibrary;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IBookingService
    {
        List<Booking> GetBookings();
        BookingDTO Add(BookingDTO bookingDTO);
        BookingDTO RemoveBooking(BookingDTO bookingDTO);
    }
}
