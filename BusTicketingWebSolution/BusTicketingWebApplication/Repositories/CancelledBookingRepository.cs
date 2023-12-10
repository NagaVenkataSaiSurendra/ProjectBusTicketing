using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class CancelledBookingRepository : ICancelledBookingRepository
    {
        private readonly TicketingContext _context;
        public CancelledBookingRepository(TicketingContext context)
        {
            _context = context;
        }

        public CancelledBooking Add(CancelledBooking item)
        {
            _context.CancelledBookings.Add(item);
            _context.SaveChanges();
            return item;
        }

        public CancelledBooking Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.CancelledBookings.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public CancelledBooking GetById(int key)
        {
            var cus = _context.CancelledBookings.SingleOrDefault(x => x.BookingId == key);
            return cus;
        }

        public IList<CancelledBooking> GetAll()
        {
            if (_context.CancelledBookings.Count() == 0)
            {
                return null;
            }
            return _context.CancelledBookings.ToList();

        }

        public CancelledBooking Update(CancelledBooking entity)
        {
            var cus = GetById(entity.BusId);
            if (cus != null)
            {
                _context.Entry<CancelledBooking>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
}

