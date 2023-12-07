using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;
        private readonly IBookedSeatService _bookedSeatService;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger,IBookedSeatService bookedSeatService)
        {
            _bookingService = bookingService;
            _logger = logger;
            _bookedSeatService= bookedSeatService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.Add(bookingDTO);
                _logger.LogInformation("Bookings are Added!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                _logger.LogError("Booking is not Added!!");
            }
            return BadRequest(errorMessage);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult GetAllBookings()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.GetBookings();
                _logger.LogInformation("Bookings listed");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                _logger.LogError("No Such Bookings are present in the collection or in the table");
            }
            return BadRequest(errorMessage);
        }

        //[Authorize(Roles = "Admin")]
        [Route("Cancel/DeleteBooking")]
        [HttpDelete]
        public ActionResult DeleteBooking(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.RemoveBooking(bookingDTO);
                _logger.LogInformation("Bookings are Deleted!!");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                _logger.LogError("Booking cannot be Deleted!!");
            }
            return BadRequest(errorMessage);
        }
        [HttpPost]
        [Route("BookedSeatsList")]
        public ActionResult BookedSeatsList(BusIdDTO busIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookedSeatService.GetSeatsById(busIdDTO);
                _logger.LogInformation("Booking done");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Booking not done");

            }
            return BadRequest(errorMessage);
        }

    }
}
