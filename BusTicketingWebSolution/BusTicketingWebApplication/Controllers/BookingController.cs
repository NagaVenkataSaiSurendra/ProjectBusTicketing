﻿using BusModelLibrary;
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
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        // [Authorize(Roles = "Admin")]
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

       // [Authorize(Roles = "Admin")]
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
            }
            return BadRequest(errorMessage);
        }

    }
}
