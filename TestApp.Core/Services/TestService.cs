using AutoMapper;
using TestApp.Core.Common;
using TestApp.Core.DTOs.Test;
using TestApp.Core.Interfaces;
using TestApp.TestApp.Core.Interfaces.IRepositories;

namespace TestApp.Core.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<Result<TestResultDTO>> CompleteTestAsync(TestCompleteDTO result)
        {
            var errors = new List<string>();
            try
            {
                var UsersTest = await _testRepository.GetUserTestsAsync(result.UserId);
                if (UsersTest.Any())
                {
                    var UserTest = UsersTest.Where(x => x.TestId == result.Id).First();
                    int trueAnswers = 0;
                    foreach (var answer in result.Answers)
                    {
                        var option = await _testRepository.GetTestQuestionOptionById(answer);
                        if (option is not null)
                        {
                            if (option.IsRight) trueAnswers++;
                        }
                    }
                    UserTest.Result = trueAnswers;
                    UserTest.isCompleted = true;
                    await _testRepository.UpdateUserTestAsync(UserTest);
                    return new Result<TestResultDTO>(true, new TestResultDTO { Id = result.Id, Result = trueAnswers });
                }
                errors.Add("No users tests");
                return new Result<TestResultDTO>(false, errors, System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return new Result<TestResultDTO>(false, errors, System.Net.HttpStatusCode.InternalServerError);
            }
    
        }

        public async Task<Result<List<TestDTO>>> GetTestsByUserIdAsync(string UserId)
        {
            var errors = new List<string>();
            try { 
            var UserTests = await _testRepository.GetUserTestsAsync(UserId);
            var Tests = new List<TestDTO>();
            foreach (var usersTest in UserTests)
            {
                var test = await _testRepository.GetTestByIdAsync(usersTest.TestId);
                if (test is not null)
                {
                    Tests.Add(new() { Id = test.Id, Name = test.Name, Description = test.Description, isCompleted = usersTest.isCompleted, Result = usersTest.Result });
                }
                else
                {
                    errors.Add("Test doesn't exist");
                }
            }
            return new Result<List<TestDTO>>(true, Tests);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return new Result<List<TestDTO>>(false, errors, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Result<List<TestQuestionDTO>>> GetTestQuestionsByTestIdAsync(Guid TestId)
        {
            var errors = new List<string>();
            try
            {
                var TestQuestions = await _testRepository.GetTestQuestionsByTestIdAsync(TestId);
                if (TestQuestions is not null)
                {
                    return new Result<List<TestQuestionDTO>>(true, _mapper.Map<List<TestQuestionDTO>>(TestQuestions));
                }
                errors.Add("No Questions");
                return new Result<List<TestQuestionDTO>>(false,errors);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return new Result<List<TestQuestionDTO>>(false, errors,System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
