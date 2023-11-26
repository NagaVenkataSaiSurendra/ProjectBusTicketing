using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusModelLibrary;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Cors;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly ILogger<BusController> _logger;

        public BusController(IBusService busService, ILogger<BusController> logger)
        {
            _busService = busService;
            _logger = logger;
        }
        //[Authorize]
        [HttpGet]
        public ActionResult GetAllBusses()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.GetBuses();
                _logger.LogInformation("Buses listed");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("No Such Buses are present in the collection or in the table");
            }
            return BadRequest(errorMessage);
        }
     // [Authorize(Roles = "Admin")]
      [HttpPost]
        public ActionResult Create(Bus bus)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.Add(bus);
                _logger.LogInformation("Buses are Added!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus is not Added!!");
            }
            return BadRequest(errorMessage);
        }


       // [Authorize(Roles = "Admin")]
        [Route("DeleteBus")]
        [HttpDelete]
        public ActionResult DeleteBus(BusIdDTO busIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.RemoveBus(busIdDTO);
                _logger.LogInformation("Bus is Deleted!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus is not Deleted!!");
            }
            return BadRequest(errorMessage);
        }

      //  [Authorize(Roles = "Admin")]
        [Route("UpdateBus")]
        [HttpPut]
        public ActionResult UpdateBus(BusDTO busDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.UpdateBus( busDTO);
                _logger.LogInformation("Bus is Updated!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus is not Updated!!");
            }
            return BadRequest(errorMessage);
        }


    }

}