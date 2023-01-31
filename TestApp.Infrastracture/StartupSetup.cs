using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Core.Enteties.User;
using TestApp.Infrastracture.DbServices.DbContext;
using TestApp.Infrastracture.DbServices.Repositories;
using TestApp.TestApp.Core.Interfaces.IRepositories;

namespace TestApp.Infrastracture
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString));
        public static void AddIdentity(this IServiceCollection services) =>
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddUserManager<UserManager<User>>();
        public static void AddRepositories(this IServiceCollection services) =>
            services.AddTransient<ITestRepository, TestRepository>();

    }
}
