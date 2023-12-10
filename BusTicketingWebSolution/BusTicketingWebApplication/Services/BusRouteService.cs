using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Repositories;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Exceptions;

namespace BusTicketingWebApplication.Services
{
    /// <summary>
    /// Service class for managing bus routes.
    /// </summary>
    public class BusRouteService : IBusRouteService
    {
        private readonly IBusRouteRepository _routeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusRouteService"/> class.
        /// </summary>
        /// <param name="repository">The repository for bus routes.</param>
        public BusRouteService(IBusRouteRepository repository)
        {
            _routeRepository = repository;
        }

        /// <summary>
        /// Adds a new bus route.
        /// </summary>
        /// <param name="busroute">The bus route information to be added.</param>
        /// <returns>The added bus route.</returns>
        public BusRoute Add(BusRoute busroute)
        {
            var result = _routeRepository.Add(busroute);
            return result;
        }

        /// <summary>
        /// Gets the list of all available bus routes.
        /// </summary>
        /// <returns>The list of bus routes.</returns>
        public List<BusRoute> GetRoutes()
        {
            var busroutes = _routeRepository.GetAll();
            if (busroutes != null)
            {
                return busroutes.ToList();
            }
            throw new NoRoutesAvailableException();
        }
    }
}
