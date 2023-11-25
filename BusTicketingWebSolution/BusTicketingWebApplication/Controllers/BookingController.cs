using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.Add(bookingDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

       // [Authorize]
        [HttpGet]
        public ActionResult GetAllBookings()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.GetBookings();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

       // [Authorize(Roles = "Admin")]
        [Route("Cancel/DeleteBooking")]
        [HttpDelete]
        public ActionResult DeleteBooking(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.RemoveBooking(bookingDTO);
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
