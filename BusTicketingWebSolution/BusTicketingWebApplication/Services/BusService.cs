using BusModelLibrary;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models.DTOs;

namespace BusTicketingWebApplication.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository repository)
        {
            _busRepository = repository;
        }
        public Bus Add(Bus bus)
        {
            var result = _busRepository.Add(bus);
            return result;
        }
        public BusIdDTO RemoveBus(BusIdDTO busIdDTO)
        {
            var BusToBeRemoved = _busRepository.GetById(busIdDTO.Id);
            if (BusToBeRemoved != null)
            {
                var result = _busRepository.Delete(busIdDTO.Id);
                if (result != null)
                {
                    return busIdDTO;
                }
            }
            return null;
        }

        public List<Bus> GetBuses()
        {
            var buses = _busRepository.GetAll();
            if (buses != null)
            {
                return buses.ToList();
            }
            throw new NoBusesAvailableException();
        }

        public BusDTO UpdateBus(BusDTO busDTO)
        {
            var busData = _busRepository.GetById(busDTO.Id);
            busData.Type = busDTO.Type;
            busData.AvailableSeats = busDTO.AvailableSeats;
            busData.BookedSeats = busDTO.BookedSeats;
            busData.Cost = busDTO.Cost;
            busData.Start = busDTO.Start;
            busData.End = busDTO.End;
            if (busData != null)
            {
                var result = _busRepository.Update(busData);
                if (result != null)
                {
                    return busDTO;
                }
            }
            return null;
        }
    }
}