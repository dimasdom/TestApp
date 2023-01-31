using TestApp.Core.Enteties.Test;

namespace TestApp.TestApp.Core.Interfaces.IRepositories
{
    public interface ITestRepository
    {
        Task<Test> GetTestByIdAsync(Guid Id);
        Task<List<Test>> GetAllTestAsync();
        Task<List<UsersTest>> GetUserTestsAsync(string UserId);
        Task<List<TestQuestion>> GetTestQuestionsByTestIdAsync(Guid TestId);
        Task<List<TestQuestionOption>> GetTestQuestionOptionsByTestQuestionIdAsync(Guid TestQuestionId);
        Task<UsersTest> UpdateUserTestAsync(UsersTest UserTest);
        Task<TestQuestionOption> GetTestQuestionOptionById(Guid TestQuestionOptionId);
    }
}
