using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ReadQuestionsController : ControllerBase
//    {
//        private readonly IReadQuestionService _questionService;

//        public ReadQuestionsController(IReadQuestionService questionService)
//        {
//            _questionService = questionService;
//        }

//        [HttpGet("by-category-exam")]
//        public async Task<IActionResult> GetByCategoryAndExam([FromQuery] int categoryId, [FromQuery] int examId)
//        {
//            var questions = await _questionService.GetQuestionsByCategoryAndExamAsync(categoryId, examId);
//            if (questions == null || !questions.Any())
//            {
//                return NotFound("No questions found for the given category and exam.");
//            }
//            return Ok(questions);
//        }
//    }
//}

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

        //[HttpGet("all-by-exam")]
        //public async Task<IActionResult> GetAllQuestions([FromQuery] int examId)
        //{
        //    var questions = await _questionService.GetAllQuestionsByExamAsync(examId);

        //    if (!questions.Any())
        //        return NotFound("No questions found for this exam.");

        //    return Ok(questions);
        //}
        [HttpGet("category/{categoryId}/exam/{examId}")]
        public async Task<ActionResult<List<QuestionDto>>> GetQuestionsByCategoryAndExam(int categoryId, int examId)
        {
            var questions = await _questionService.GetQuestionsByCategoryAndExamAsync(categoryId, examId);

            if (questions == null || questions.Count == 0)
            {
                return NotFound("No questions found for the given category and exam.");
            }

            return Ok(questions);
        }
    }
    }


