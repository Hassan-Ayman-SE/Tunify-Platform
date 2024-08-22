using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{

    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto registerDto)
        {
            try
            {
                var user = new IdentityUser { UserName = registerDto.Username, Email = registerDto.Email };
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                return result;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error during registration: {ex.Message}");
                // Return a failed IdentityResult with error details
                return IdentityResult.Failed(new IdentityError { Description = $"Exception: {ex.Message}" });
            }
        }

        public async Task<bool> LoginUser(LoginDto loginDto)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error during login: {ex.Message}");
                return false;
            }
        }

        public async Task LogoutUser()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error during logout: {ex.Message}");
            }
        }
    }
}