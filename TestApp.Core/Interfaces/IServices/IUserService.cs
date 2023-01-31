using Microsoft.AspNetCore.Identity;
using TestApp.Core.Common;
using TestApp.Core.DTOs.User;

namespace TestApp.Core.Interfaces
{
    public interface IUserService
    {
        Task<Result<IdentityResult>> CreateUser(RegisterDTO registrationDTO);
        Task<Result<string>> Login(LoginDTO loginDTO);
    }
}
