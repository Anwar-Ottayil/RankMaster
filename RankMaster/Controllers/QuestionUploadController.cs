using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers    
{
  




    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("upload-csv")]
        public async Task<IActionResult> UploadQuestions([FromForm] QuestionCsvUploadDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("CSV file is required.");

            var result = await _questionService.UploadQuestionsFromCsvAsync(dto);
            return Ok(new { message = result });
        }
    }
}
