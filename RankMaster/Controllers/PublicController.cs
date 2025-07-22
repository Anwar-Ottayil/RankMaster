using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Coordinator")]
        public async Task<IActionResult> Create(CreateAnnouncementDto dto)
        {
            var result = await _announcementService.AddAnnouncementAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Coordinator")]
        public async Task<IActionResult> Update(int id, UpdateAnnouncementDto dto)
        {
            var result = await _announcementService.UpdateAnnouncementAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Coordinator")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _announcementService.DeleteAnnouncementAsync(id);
            return success ? Ok() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _announcementService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
