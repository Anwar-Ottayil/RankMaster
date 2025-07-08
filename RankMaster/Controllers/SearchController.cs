using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [ApiController]
    [Route("api/exams")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _examService;

        public SearchController(ISearchService examService)
        {
            _examService = examService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            var results = await _examService.SearchExamsAsync(keyword);
            return Ok(results);
        }
    }
}
