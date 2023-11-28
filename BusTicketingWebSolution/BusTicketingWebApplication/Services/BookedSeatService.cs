using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Repositories;

namespace BusTicketingWebApplication.Services
{
    public class BookedSeatService : IBookedSeatService
    {
        private readonly IBookedSeatRepository _bookedSeatRepository;
        private readonly IBusRepository _busRepository;
        public BookedSeatService(IBookedSeatRepository bookedSeatRepository, IBusRepository busRepository)
        {
            _bookedSeatRepository = bookedSeatRepository;
            _busRepository = busRepository;

        }
        public List<int> GetSeatsById(BusIdDTO busIdDTO)
        {
            var bus = _bookedSeatRepository.GetById(busIdDTO.Id);
            if (bus != null)
            {
                return bus.BookedSeats;


            }
            return null;
        }
    }
}