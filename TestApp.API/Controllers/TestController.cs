
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestApp.Core.Common;
using TestApp.Core.DTOs.Test;
using TestApp.Core.Interfaces;

namespace TestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestController(ITestService testService, IHttpContextAccessor httpContextAccessor)
        {
            _testService = testService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<Result<List<TestDTO>>>> GetUserTests()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _testService.GetTestsByUserIdAsync(userId);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("TestQuestions")]
        public async Task<ActionResult<Result<List<TestQuestionDTO>>>> GetTestQuestions(Guid TestId)
        {
            return await _testService.GetTestQuestionsByTestIdAsync(TestId);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Complete")]
        public async Task<ActionResult<Result>> CompleteTest([FromBody] TestCompleteDTO testCompleteDTO)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            testCompleteDTO.UserId = userId;
            return await _testService.CompleteTestAsync(testCompleteDTO);
        }
    }
}
