using ErdAndEF.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;

        public AccountController(IAccount accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {


            var user = await _accountService.RegisterUser(registerDto, this.ModelState);


            if (ModelState.IsValid)
            {
                return user;
            }


            if (user == null)
            {
                return Unauthorized();
            }

            return BadRequest();
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _accountService.LoginUser(loginDto);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [Authorize(Roles = "Admin")] 
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDto>> Profile()
        {
            return await _accountService.UserProfile(User);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.LogoutUser();
                return Ok("Logout successful");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error during logout: {ex.Message}");

                // Return a generic error message to the client
                return StatusCode(500, "An error occurred during logout. Please try again later.");
            }
        }

    }
}
