using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zuri.Dtos;

namespace Zuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController (ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequisitionDto loginRequisition)
        {
            try
            {
                if(!String.IsNullOrEmpty(loginRequisition.Password) && !String.IsNullOrEmpty(loginRequisition.Email) &&
                    !String.IsNullOrWhiteSpace(loginRequisition.Password) && !String.IsNullOrWhiteSpace(loginRequisition.Email))
                {
                    string email = "coutinho@gmail.com";
                    string password = "coutinho1996";

                    if(loginRequisition.Email == email && loginRequisition.Password == password)
                    {
                        return Ok(new LoginRequisitionDto()
                        {
                            Email = email,
                            Nome = "Flavio Coutinho"
                        }) ;
                    }
                    else
                    {
                        return BadRequest(new ErrorResponseDto()
                        {
                            Description = "Invalid email or password"
                        });
                    }
                }
                else
                {
                    return BadRequest(new ErrorResponseDto()
                    {
                        Description = "User did not fill in the login fields correctly",
                        Status = StatusCodes.Status400BadRequest,
                    });
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error logging in: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "Error ocurred while logging in",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }
        }
    }
}
