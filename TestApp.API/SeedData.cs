using Microsoft.AspNetCore.Identity;
using TestApp.Core.Enteties.Test;
using TestApp.Core.Enteties.User;
using TestApp.Infrastracture.DbServices.DbContext;

namespace TestApp.API
{
    public class SeedData
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public SeedData(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Initialize(IServiceProvider serviceProvider)
        {
            if (!_context.Users.Where(u => u.Email == "userOne@mail.com").Any())
            {
                await CreateUsers();
            }
            if (!_context.Tests.Any())
            {
                await CreateTests();
            }
        }
        private async Task CreateTests()
        {
            var user = await _userManager.FindByEmailAsync("userOne@mail.com");
            Test test = new() { Name = "Test1", Description = "Description for Test1" };
            await _context.Tests.AddAsync(test);
            List<TestQuestion> testQuestions = new List<TestQuestion>();
            testQuestions.Add(new TestQuestion { Description = "Test Question1", TestId = test.Id });
            testQuestions.Add(new TestQuestion { Description = "Test Question2", TestId = test.Id });
            testQuestions.Add(new TestQuestion { Description = "Test Question3", TestId = test.Id });
            testQuestions.Add(new TestQuestion { Description = "Test Question4", TestId = test.Id });
            testQuestions.Add(new TestQuestion { Description = "Test Question5", TestId = test.Id });
            foreach (var testQuestion in testQuestions)
            {
                _context.TestQuestions.Add(testQuestion);
                testQuestion.Options.Add(new() { Description = "Test Question Option 1", IsRight = true, TestId = test.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 2", IsRight = false, TestId = test.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 3", IsRight = false, TestId = test.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 4", IsRight = false, TestId = test.Id, TestQuestionId = testQuestion.Id });
            }
            UsersTest userTest = new() { UserId = user.Id, TestId = test.Id, isCompleted = false, Result = 0 };
            var user2 = await _userManager.FindByEmailAsync("userTwo@mail.com");
            Test test2 = new() { Name = "Test2", Description = "Description for Test2" };
            await _context.Tests.AddAsync(test2);
            List<TestQuestion> testQuestions2 = new List<TestQuestion>();
            testQuestions2.Add(new TestQuestion { Description = "Test Question1", TestId = test2.Id });
            testQuestions2.Add(new TestQuestion { Description = "Test Question2", TestId = test2.Id });
            testQuestions2.Add(new TestQuestion { Description = "Test Question3", TestId = test2.Id });
            testQuestions2.Add(new TestQuestion { Description = "Test Question4", TestId = test2.Id });
            testQuestions2.Add(new TestQuestion { Description = "Test Question5", TestId = test2.Id });
            foreach (var testQuestion in testQuestions2)
            {
                _context.TestQuestions.Add(testQuestion);
                testQuestion.Options.Add(new() { Description = "Test Question Option 1", IsRight = true, TestId = test2.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 2", IsRight = false, TestId = test2.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 3", IsRight = false, TestId = test2.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 4", IsRight = false, TestId = test2.Id, TestQuestionId = testQuestion.Id });
            }
            UsersTest userTest2 = new() { UserId = user2.Id, TestId = test2.Id, isCompleted = false, Result = 0 };
            var user3 = await _userManager.FindByEmailAsync("userThird@mail.com");
            Test test3 = new() { Name = "Test3", Description = "Description for Test3" };
            await _context.Tests.AddAsync(test3);
            List<TestQuestion> testQuestions3 = new List<TestQuestion>();
            testQuestions3.Add(new TestQuestion { Description = "Test Question1", TestId = test3.Id });
            testQuestions3.Add(new TestQuestion { Description = "Test Question2", TestId = test3.Id });
            testQuestions3.Add(new TestQuestion { Description = "Test Question3", TestId = test3.Id });
            testQuestions3.Add(new TestQuestion { Description = "Test Question4", TestId = test3.Id });
            testQuestions3.Add(new TestQuestion { Description = "Test Question5", TestId = test3.Id });
            foreach (var testQuestion in testQuestions3)
            {
                _context.TestQuestions.Add(testQuestion);
                testQuestion.Options.Add(new() { Description = "Test Question Option 1", IsRight = true, TestId = test3.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 2", IsRight = false, TestId = test3.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 3", IsRight = false, TestId = test3.Id, TestQuestionId = testQuestion.Id });
                testQuestion.Options.Add(new() { Description = "Test Question Option 4", IsRight = false, TestId = test3.Id, TestQuestionId = testQuestion.Id });
            }
            UsersTest userTest3 = new() { UserId = user3.Id, TestId = test3.Id, isCompleted = false, Result = 0 };
            await _context.UsersTests.AddAsync(userTest);
            await _context.UsersTests.AddAsync(userTest2);
            await _context.UsersTests.AddAsync(userTest3);
            _context.SaveChanges();
        }
        private async Task CreateUsers()
        {
            await _userManager.CreateAsync(new User { Email = "userOne@mail.com", UserName = "userOne@mail.com" }, "123456Aa");
            await _userManager.CreateAsync(new User { Email = "userTwo@mail.com", UserName = "userTwo@mail.com" }, "123456Aa");
            await _userManager.CreateAsync(new User { Email = "userThird@mail.com", UserName = "userThird@mail.com" }, "123456Aa");
            //await _context.SaveChanges();
        }
    }
}
