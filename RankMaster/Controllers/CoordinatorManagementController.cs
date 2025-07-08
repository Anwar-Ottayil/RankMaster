using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [ApiController]
    [Route("api/admin/coordinators")]
    //[Authorize(Roles = "Admin")]
    public class CoordinatorManagementController : ControllerBase
    {
        private readonly ICoordinatorManagementService _service;

        public CoordinatorManagementController(ICoordinatorManagementService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCoordinator([FromForm] CreateCoordinatorDto dto)
        {
            await _service.RegisterCoordinatorAsync(dto);
            return Ok(new { message = "Coordinator registered and categories assigned." });
        }
    }
}
