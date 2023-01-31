
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Enteties.Test;
using TestApp.Core.Enteties.User;

namespace TestApp.Infrastracture.DbServices.DbContext
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }

        public DbSet<TestQuestionOption> TestQuestionOptions { get; set; }

        public DbSet<UsersTest> UsersTests { get; set; }

    }
}
