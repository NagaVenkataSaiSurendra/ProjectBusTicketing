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
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IUserService userService, ILogger<CustomerController> logger)
        {
            _userService = userService;
            _logger = logger;
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
                    _logger.LogInformation("Customer is Registered!!");
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
                _logger.LogInformation("Customers are Logged In!!");
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
                _logger.LogInformation("Bus Search is listed!!");
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
                _logger.LogInformation("User Booking History is Fetched!!");
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
                _logger.LogInformation("Users listed");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("No Such Users are present in the collection or in the table");
            }
            return BadRequest(errorMessage);

        }
        [HttpPut]
        [Route("UserProfiles")]
        public ActionResult UserProfiles(UserDataDTO userDataDTO)
        {
            string msg = "";
            try
            {
                var res = _userService.UpdateUser(userDataDTO);
                _logger.LogInformation("Users profiles are listed!!");
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
