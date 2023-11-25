using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteService _busRouteService;

        public BusRouteController(IBusRouteService busRouteService)
        {
            _busRouteService = busRouteService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busRouteService.GetRoutes();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
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
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        //[authorize]
        //[httpget]
        //public actionresult getallroutes()
        //{
        //    string errormessage = string.empty;
        //    try
        //    {
        //        var result = _busrouteservice.getroutes();
        //        return ok(result);
        //    }
        //    catch (exception e)
        //    {
        //        errormessage = e.message;
        //    }
        //    return badrequest(errormessage);
        //}
    }
}
