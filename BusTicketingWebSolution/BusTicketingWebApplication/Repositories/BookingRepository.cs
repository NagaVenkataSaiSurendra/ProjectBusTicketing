using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TicketingContext _context;
        public BookingRepository(TicketingContext context)
        {
            _context = context;
        }

        public Booking Add(Booking item)
        {
            _context.Bookings.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Booking Delete(int key)
        {
            var booking = GetById(key);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            return null;
        }

        public Booking GetById(int key)
        {
            var cus = _context.Bookings.SingleOrDefault(x => x.BookingId == key);
            return cus;
        }

        public IList<Booking> GetAll()
        {
            if (_context.Bookings.Count() == 0)
            {
                return null;
            }
            return _context.Bookings.ToList();

        }

        public Booking Update(Booking entity)
        {
            var cus = GetById(entity.BookingId);
            if (cus != null)
            {
                _context.Entry<Booking>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
}
