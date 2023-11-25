using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }


            return BadRequest(message);
        }

        [HttpPost]
        [Route("Login")]//attribute based routing
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }

        [HttpPost]
        [Route("BusSearch")]
        public ActionResult BusSearch(BusDTO busDTO) 
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.BusSearch(busDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }
        [HttpPost]
        [Route("UserBookingHistory")]
        public ActionResult BookingHistory(UserIdDTO userIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetBookingHistory(userIdDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }
        [HttpPut]
        [Route("UserProfiles")]
        public ActionResult UserProfiles(UserDTO userDTO)
        {
            string msg = "";
            try
            {
                var res = _userService.UpdateUser(userDTO);
                return Ok(res);
            }
            catch(Exception e)
            {
                msg=e.Message;
            }
            return BadRequest(msg);
        }


        
    }
}
