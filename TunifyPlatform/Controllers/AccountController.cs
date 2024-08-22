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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid registration details");

            var result = await _accountService.RegisterUser(registerDto);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            // Collect all errors and return them in the response
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Message = "Registration failed", Errors = errors });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid login details");

            var result = await _accountService.LoginUser(loginDto);
            if (result)
                return Ok("Login successful");
            return Unauthorized("Login failed");
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
