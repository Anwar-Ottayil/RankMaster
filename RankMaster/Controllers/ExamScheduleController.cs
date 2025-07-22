using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScheduleController : ControllerBase
    {
        private readonly IExamScheduleService _scheduleService;

        public ExamScheduleController(IExamScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // POST: api/admin/schedule-exam
        [Authorize(Roles = "Admin,Coordinator")]

        [HttpPost("schedule-exam")]
        public async Task<IActionResult> ScheduleExam([FromBody] CreateExamScheduleDto dto)
        {
            var success = await _scheduleService.CreateScheduleAsync(dto);
            if (!success)
                return BadRequest("Failed to schedule exam");

            return Ok("Exam scheduled successfully");
        }
    }
}

