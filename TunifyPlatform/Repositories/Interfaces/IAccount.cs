using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> RegisterUser(RegisterDto registerDto);
        Task<bool> LoginUser(LoginDto loginDto);
        Task LogoutUser();
    }
}
