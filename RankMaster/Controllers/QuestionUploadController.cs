using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers    
{
    //[ApiController]
    //[Route("api/coordinator/questions")]
    //public class QuestionUploadController : ControllerBase
    //{
    //    private readonly IQuestionService _questionService;

    //    public QuestionUploadController(IQuestionService questionService)
    //    {
    //        _questionService = questionService;
    //    }

    //    [HttpPost("UploadCsv")]
    //    public async Task<IActionResult> UploadCsv([FromForm] ExamAdddto dto)
    //    {
    //        if (dto.File == null || dto.File.Length == 0)
    //            return BadRequest("File is empty.");

    //        var result = await _questionService.UploadCsvAsync(dto.File, dto.ExamId, dto.CategoryId);
    //        return Ok(result);
    //    }
    //}




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
