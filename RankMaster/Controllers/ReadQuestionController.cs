using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadQuestionsController : ControllerBase
    {
        private readonly IReadQuestionService _questionService;

        public ReadQuestionsController(IReadQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("by-category-exam")]
        public async Task<IActionResult> GetByCategoryAndExam([FromQuery] int categoryId, [FromQuery] int examId)
        {
            var questions = await _questionService.GetQuestionsByCategoryAndExamAsync(categoryId, examId);
            if (questions == null || !questions.Any())
            {
                return NotFound("No questions found for the given category and exam.");
            }
            return Ok(questions);
        }
    }
}
