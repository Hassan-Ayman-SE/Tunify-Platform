using ErdAndEF.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        Task<UserDto> RegisterUser(RegisterDto registerDto, ModelStateDictionary modelState);
        Task<UserDto> LoginUser(LoginDto loginDto);
        Task LogoutUser();
        // add user profile 
        public Task<UserDto> UserProfile(ClaimsPrincipal claimsPrincipal);

    }
}
