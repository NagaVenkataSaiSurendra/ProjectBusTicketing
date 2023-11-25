using BusModelLibrary;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Repositories;

namespace BusTicketingWebApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBusRepository _busRepository;

        private readonly IUserRepository _userRepository;


        public BookingService(IBookingRepository bookingRepository, IBusRepository busRepository, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _busRepository = busRepository;

        }
        public BookingDTO Add(BookingDTO bookingDTO)
        {
            var bus = _busRepository.GetById(bookingDTO.BusId);
            if (bookingDTO.NoOfSeats <= 0 && bookingDTO.NoOfSeats > 40) 
                throw new InvalidNoOfTicketsEnteredException();
            if (bookingDTO.NoOfSeats <= bus.AvailableSeats && bus.AvailableSeats > 0)
            {
                float Fare = 0;

                if (bus != null)
                {
                    Fare = bus.Cost;
                    bus.AvailableSeats -= bookingDTO.NoOfSeats;
                    bus.BookedSeats += bookingDTO.NoOfSeats;
                    _busRepository.Update(bus);
                }
                else
                {
                    throw new InvalidBusIdException();
                }
                Booking booking = new Booking
                {
                    UserId = bookingDTO.UserId,
                    BusId = bookingDTO.BusId,
                    Date = bookingDTO.Date,
                    NoOfSeats = bookingDTO.NoOfSeats,
                    TotalFare = bookingDTO.NoOfSeats * Fare
                };
                var result = _bookingRepository.Add(booking);
            }
            else
            {
                throw new NotEnoughBusSeatsAvailableException();
            }




            return bookingDTO;
        }

        public List<Booking> GetBookings()
        {
            var bookings = _bookingRepository.GetAll();
            if (bookings != null)
            {
                return bookings.ToList();
            }
            throw new NoBookingsAvailableException();
        }



        public BookingDTO RemoveBooking(BookingDTO bookingDTO)
        {
            var BookingToBeRemoved = _bookingRepository.GetById(bookingDTO.Id);
            if (BookingToBeRemoved != null)
            {
                var result = _bookingRepository.Delete(bookingDTO.Id);
                if (result != null)
                {
                    return bookingDTO;
                }
            }
            return null;
        }
    }
}
