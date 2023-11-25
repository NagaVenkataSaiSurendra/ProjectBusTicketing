using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly TicketingContext _context;
        public BusRepository(TicketingContext context)
        {
            _context = context;
        }

        public Bus Add(Bus item)
        {
            _context.Buses.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Bus Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.Buses.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public Bus GetById(int key)
        {
            var cus=_context.Buses.SingleOrDefault(x => x.Id == key);
            return cus;
        }

        public IList<Bus> GetAll()
        {
            if (_context.Buses.Count()==0)
            {
                return null;
            }
            return _context.Buses.ToList();

        }

        public Bus Update(Bus entity)
        {
            var cus = GetById(entity.Id);
            if (cus != null)
            {
                _context.Entry<Bus>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
    }

