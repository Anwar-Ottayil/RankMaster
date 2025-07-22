using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamIspaidController : ControllerBase
    {
        private readonly IExamServiceIspaid _examService;

        public ExamIspaidController(IExamServiceIspaid examService)
        {
            _examService = examService;
        }

        [HttpGet("paid")]
        public async Task<IActionResult> GetPaidExams()
        {
            var exams = await _examService.GetPaidExamsAsync();
            return Ok(exams);
        }

        [HttpGet("free")]
        public async Task<IActionResult> GetFreeExams()
        {
            var exams = await _examService.GetFreeExamsAsync();
            return Ok(exams);
        }
    }
}
