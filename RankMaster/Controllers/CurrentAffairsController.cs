using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentAffairsController : ControllerBase
    {
        private readonly ICurrentAffairsService _service;

        public CurrentAffairsController(ICurrentAffairsService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCurrentAffairsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Coordinator")]
        public async Task<IActionResult> Add([FromBody] CreateCurrentAffairDto dto)
        {
            var result = await _service.AddCurrentAffairAsync(dto);
            return Ok(result);
        }
    }
}
