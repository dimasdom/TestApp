using Microsoft.EntityFrameworkCore;
using TestApp.Core.Enteties.Test;
using TestApp.Infrastracture.DbServices.DbContext;
using TestApp.TestApp.Core.Interfaces.IRepositories;

namespace TestApp.Infrastracture.DbServices.Repositories
{
#pragma warning disable CS0246 // The type or namespace name 'ITestRepository' could not be found (are you missing a using directive or an assembly reference?)
    public class TestRepository : ITestRepository
#pragma warning restore CS0246 // The type or namespace name 'ITestRepository' could not be found (are you missing a using directive or an assembly reference?)
    {
        private readonly AppDbContext _dbContext;

        public TestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<Test>> GetAllTestAsync()
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.Tests.ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<TestQuestionOption>> GetQuestionOptionsAsync(Guid TestQuestionId)
#pragma warning restore CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.TestQuestionOptions.Where(x => x.TestQuestionId == TestQuestionId).ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<Test> GetTestByIdAsync(Guid Id)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbContext.Tests.FindAsync(Id);
#pragma warning restore CS8603 // Possible null reference return.
        }

#pragma warning disable CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<TestQuestionOption> GetTestQuestionOptionById(Guid TestQuestionOptionId)
#pragma warning restore CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbContext.TestQuestionOptions.FindAsync(TestQuestionOptionId);
#pragma warning restore CS8603 // Possible null reference return.
        }

#pragma warning disable CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<TestQuestionOption>> GetTestQuestionOptionsByTestQuestionIdAsync(Guid TestQuestionId)
#pragma warning restore CS0246 // The type or namespace name 'TestQuestionOption' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.TestQuestionOptions.Where(t => t.TestQuestionId == TestQuestionId).ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'TestQuestion' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<TestQuestion>> GetTestQuestionsAsync(Guid TestId)
#pragma warning restore CS0246 // The type or namespace name 'TestQuestion' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.TestQuestions.Where(x => x.TestId == TestId).Include(t => t.Options).ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'TestQuestion' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<TestQuestion>> GetTestQuestionsByTestIdAsync(Guid TestId)
#pragma warning restore CS0246 // The type or namespace name 'TestQuestion' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.TestQuestions.Where(t => t.TestId == TestId).Include(t => t.Options).ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<List<UsersTest>> GetUserTestsAsync(string UserId)
#pragma warning restore CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
        {
            return await _dbContext.UsersTests.Where(x => x.UserId == UserId).ToListAsync();
        }

#pragma warning disable CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<UsersTest> UpdateUserTestAsync(UsersTest UserTest)
#pragma warning restore CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'UsersTest' could not be found (are you missing a using directive or an assembly reference?)
        {
            var userTest = await _dbContext.UsersTests.FindAsync(UserTest.Id);
            if (userTest is not null)
            {
                userTest.isCompleted = UserTest.isCompleted;
                userTest.Result = UserTest.Result;
                await _dbContext.SaveChangesAsync();
                return userTest;
            }
            throw new Exception("No entity");
        }
    }
}
