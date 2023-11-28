using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using static BusTicketingWebApplication.Repositories.BookedSeatRepository;

namespace BusTicketingWebApplication.Repositories
{


    public class BookedSeatRepository : IBookedSeatRepository
    {
        private readonly TicketingContext _context;
        public BookedSeatRepository(TicketingContext context)
        {
            _context = context;
        }

        public BookedSeat Add(BookedSeat item)
        {
            _context.BookedSeats.Add(item);
            _context.SaveChanges();
            return item;
        }

        public BookedSeat Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.BookedSeats.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public BookedSeat GetById(int key)
        {
            var cus = _context.BookedSeats.SingleOrDefault(x => x.BusId == key);
            return cus;
        }

        public IList<BookedSeat> GetAll()
        {
            if (_context.BookedSeats.Count() == 0)
            {
                return null;
            }
            return _context.BookedSeats.ToList();

        }

        public BookedSeat Update(BookedSeat entity)
        {
            var cus = GetById(entity.BusId);
            if (cus != null)
            {
                _context.Entry<BookedSeat>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
}


