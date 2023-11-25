using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class BusRouteRepository : IBusRouteRepository
    {
        private readonly TicketingContext _context;
        public BusRouteRepository(TicketingContext context)
        {
            _context = context;
        }
        public BusRoute Add(BusRoute item)
        {
            _context.BusRoutes.Add( item);
            _context.SaveChanges();
            return item;
        }

        public BusRoute Delete(int key)
        {
            var busRoute = GetById(key);
            if (busRoute != null)
            {
                _context.BusRoutes.Remove(busRoute);
                _context.SaveChanges();
                return busRoute;
            }
            return null;
        }

        public IList<BusRoute> GetAll()
        {
            if (_context.BusRoutes.Count() == 0)
            {
                return null;
            }
            return _context.BusRoutes.ToList();
        }

        public BusRoute GetById(int key)
        {
            var cus = _context.BusRoutes.SingleOrDefault(x => x.RouteId == key);
            return cus;
        }

        public BusRoute Update(BusRoute entity)
        {
            var cus = GetById(entity.RouteId);
            if (cus != null)
            {
                _context.Entry<BusRoute>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
}
