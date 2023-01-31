using TestApp.Core.Common;
using TestApp.Core.DTOs.Test;

namespace TestApp.Core.Interfaces
{
    public interface ITestService
    {
        Task<Result<List<TestDTO>>> GetTestsByUserIdAsync(string UserId);
        Task<Result<List<TestQuestionDTO>>> GetTestQuestionsByTestIdAsync(Guid TestId);
        Task<Result<TestResultDTO>> CompleteTestAsync(TestCompleteDTO result);
    }
}
