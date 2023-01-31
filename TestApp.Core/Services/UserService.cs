using Microsoft.AspNetCore.Identity;
using TestApp.Core.Common;
using TestApp.Core.DTOs.User;
using TestApp.Core.Enteties.User;
using TestApp.Core.Interfaces;
using TestApp.Core.Interfaces.IServices;

namespace TestApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<IdentityResult>> CreateUser(RegisterDTO registrationDTO)
        {
            var errors = new List<string>();
            try
            {
                var result = await _userManager.CreateAsync(new User { Email = registrationDTO.Email, UserName = registrationDTO.Email }, registrationDTO.Password);
                return new Result<IdentityResult>(result.Succeeded, result);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return new Result<IdentityResult>(false, errors, null, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Result<string>> Login(LoginDTO loginDTO)
        {
            var errors = new List<string>();
            try
            {
                var User = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (User is not null)
                {
                    var result = await _userManager.CheckPasswordAsync(User, loginDTO.Password);
                    if (result)
                    {
                        return new Result<string>(result, _tokenService.CreateToken(User));
                    }

                }
                errors.Add("There are no User");
                return new Result<string>(false, errors);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return new Result<string>(false, errors, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
