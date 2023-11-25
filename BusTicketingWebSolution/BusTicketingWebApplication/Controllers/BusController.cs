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

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
      //[Authorize]
      [HttpGet]
        public ActionResult GetAllBusses()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.GetBuses();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
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
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
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
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
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
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }


    }

}