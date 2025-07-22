using Application.Dto;
using Application.Interface.ServiceInterface;
using Application.Interfaces.RepositoryInterface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamAttemptController : ControllerBase
    {
        private readonly IExamAttemptService _service;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepo;

        public ExamAttemptController(IExamAttemptService service, IQuestionRepository questionRepo, IMapper mapper)
        {
            _service = service;
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        [Authorize] // Ensure the route is protected
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAttempt([FromBody] ExamAttemptCreateDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            var attempt = new ExamAttempt
            {
                ExamId = dto.ExamId,
                UserId = userId, // Automatically from token
                AttemptedAt = DateTime.UtcNow,
                Answers = new List<ExamAnswer>()
            };

            int score = 0;

            foreach (var ans in dto.Answers)
            {
                var question = await _questionRepo.GetByIdAsync(ans.QuestionId);
                if (question == null) continue;

                bool isCorrect = question.CorrectOption.Equals(ans.SelectedOption, StringComparison.OrdinalIgnoreCase);

                attempt.Answers.Add(new ExamAnswer
                {
                    QuestionId = question.Id,
                    SelectedOption = ans.SelectedOption,
                    IsCorrect = isCorrect
                });

                if (isCorrect) score++;
            }

            attempt.Score = score;
            await _service.AddAttemptAsync(attempt);

            return Ok(new { attemptId = attempt.Id, score = attempt.Score });
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAttemptsByUser(int userId)
        {
            var attempts = await _service.GetAttemptsByUserIdAsync(userId);

            var resultDtos = attempts.Select(a => new ExamAttemptResultDto
            {
                AttemptId = a.Id,
                ExamId = a.ExamId,
                UserId = a.UserId,
                AttemptedAt = a.AttemptedAt,
                Score = a.Score,
                Answers = a.Answers?.Select(ans => new ExamAnswerResultDto
                {
                    QuestionId = ans.QuestionId,
                    SelectedOption = ans.SelectedOption,
                    IsCorrect = ans.IsCorrect
                }).ToList()
            }).ToList();

            return Ok(resultDtos);
        }


        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetAttemptsByExam(int examId)
        {
            var attempts = await _service.GetAttemptsByExamIdAsync(examId);
            return Ok(attempts.Select(_mapper.Map<ExamAttemptResultDto>));
        }


     [HttpGet("score")]
    public async Task<IActionResult> GetTotalScoreByUser()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized("User ID not found in token.");

        int userId = int.Parse(userIdClaim.Value);

        var totalScore = await _service.GetTotalScoreByUserIdAsync(userId);
        return Ok(new { userId, totalScore });
    }
        [HttpGet("Admin")]
        public async Task<IActionResult> GetTotalScoreByUser([FromQuery] int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid user ID.");

            var totalScore = await _service.GetTotalScoreByUserIdAsync(userId);
            return Ok(new { userId, totalScore });
        }




    }
}
