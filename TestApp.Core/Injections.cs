using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestApp.Core.Interfaces;
using TestApp.Core.Interfaces.IServices;
using TestApp.Core.Services;

namespace TestApp.Core
{
    public static class Injections
    {
        public static void RegisterServices(this IServiceCollection services) => services
            .AddTransient<ITestService, TestService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<ITokenService, TokenService>();
        public static void AddJwtAuthentication(this IServiceCollection services) => services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("If you see it , hello")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
    }
}
