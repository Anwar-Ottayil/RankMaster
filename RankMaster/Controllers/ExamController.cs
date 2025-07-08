using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null) return NotFound();
            return Ok(exam);
        }

        //[Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<ExamDto> examDtos)
        {
            if (examDtos == null || !examDtos.Any())
                return BadRequest("No exams to add.");

            await _examService.AddExamsAsync(examDtos);
            return Ok("Exams added successfully.");
        }
        [Authorize(Roles = "Admin,Coordinator")]

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExamDto examDto)
        {
            await _examService.UpdateExamAsync(id, examDto);
            return Ok("Exam updated");
        }
        [Authorize(Roles = "Admin,Coordinator")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examService.DeleteExamAsync(id);
            return Ok("Exam deleted");
        }
    }
}
