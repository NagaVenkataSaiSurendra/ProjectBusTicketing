using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteService _busRouteService;
        private readonly ILogger<BusRouteController> _logger;

        public BusRouteController(IBusRouteService busRouteService, ILogger<BusRouteController> logger)
        {
            _busRouteService = busRouteService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busRouteService.GetRoutes();
                _logger.LogInformation("BUs Routes listed");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                _logger.LogError("No Such Bus Routes are present in the collection");
            }
            return BadRequest(errorMessage);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BusRoute busRoute)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busRouteService.Add(busRoute);
                _logger.LogInformation("Bus Routes are Added!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                _logger.LogError("Bus Route is not added!!");
            }
            return BadRequest(errorMessage);
        }

        
    }
}
