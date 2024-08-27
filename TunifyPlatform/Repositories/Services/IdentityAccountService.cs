using ErdAndEF.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{

    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;
        public IdentityAccountService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;

        }

        public async Task<UserDto> RegisterUser(RegisterDto registerDto, ModelStateDictionary modelState)
        {
            var user = new IdentityUser()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // add roles to the new rigstred user
                await _userManager.AddToRolesAsync(user, registerDto.Roles);


                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user),
                    Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(7))

                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerDto) :
                                error.Code.Contains("Email") ? nameof(registerDto) :
                                error.Code.Contains("Username") ? nameof(registerDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }


            return null;
        }

        public async Task<UserDto> LoginUser(LoginDto loginDto)
        {
            //try
            //{
            //    var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            //    return result.Succeeded;
            //}
            //catch (Exception ex)
            //{
            //    // Log exception
            //    Console.WriteLine($"Error during login: {ex.Message}");
            //    return false;
            //}

            var user = await _userManager.FindByNameAsync(loginDto.Username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(7))

                };
            }

            return null;
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

        public async Task<UserDto> UserProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(30)) // just for development purposes
            };
        }

    }
}