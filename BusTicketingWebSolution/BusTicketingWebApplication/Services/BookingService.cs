using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using System.Linq;

namespace BusTicketingWebApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBusRepository _busRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookedSeatRepository _bookedSeatRepository;


        public BookingService(IBookingRepository bookingRepository, IBusRepository busRepository, IUserRepository userRepository, IBookedSeatRepository bookedSeatRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _busRepository = busRepository;
            _bookedSeatRepository = bookedSeatRepository;
        }
        public BookingDTO Add(BookingDTO bookingDTO)
        {
            var bus = _busRepository.GetById(bookingDTO.BusId);
            if (bookingDTO.SelectedSeats.Count <= 0 && bookingDTO.SelectedSeats.Count > 40) throw new InvalidNoOfTicketsEnteredException();
            if (bookingDTO.SelectedSeats.Count <= bus.AvailableSeats && bus.AvailableSeats > 0)
            {
                float Fare = 0;
                if (bus != null)
                {
                    Fare = bus.Cost;
                    bus.AvailableSeats -= bookingDTO.SelectedSeats.Count;
                    bus.BookedSeats += bookingDTO.SelectedSeats.Count;
                    _busRepository.Update(bus);
                    if (bookingDTO.SelectedSeats != null)
                    {
                        var bookedBusSeats = _bookedSeatRepository.GetById(bookingDTO.BusId);
                        if (bookedBusSeats == null)
                        {
                            BookedSeat bookedSeat = new BookedSeat();
                            bookedSeat.BusId = bus.Id;
                            bookedSeat.BookedSeats = bookingDTO.SelectedSeats;
                            _bookedSeatRepository.Add(bookedSeat);
                        }
                        else
                        {

                            //bookedBusSeats.BookedSeats  = new List<int>(bookedBusSeats.BookedSeats.Count +
                            //      bookingDTO.SelectedSeats.Count );

                            bookedBusSeats.BookedSeats.AddRange(bookingDTO.SelectedSeats);

                            // bookedBusSeats.BookedSeats= bookedBusSeats.BookedSeats.Concat(bookingDTO.SelectedSeats).ToList;

                            _bookedSeatRepository.Update(bookedBusSeats);
                        }
                    }
                }
                else
                {
                    throw new InvalidBusIdException();
                }
                Booking booking = new Booking
                {
                    UserName = bookingDTO.UserName,
                    BusId = bookingDTO.BusId,
                    Date = bookingDTO.Date,
                    SelectedSeats = bookingDTO.SelectedSeats,
                    TotalFare = bookingDTO.SelectedSeats.Count * Fare
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
