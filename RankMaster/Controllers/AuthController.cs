using Application.Dto;
using Application.Interfaces.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RankMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _userService;
        public UserController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterDto register)
        {
            try
            {
                var result = await _userService.Register(register);
                if (result.StatusCode == 200)
                {
                    return Ok(result);
                }
                else if (result.StatusCode == 400)
                {
                    return BadRequest(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,result.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseDto<string>(400, ex.Message, null));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginDto login)
        {
            //try
            //{
                var result = await _userService.Login(login);
                if (result.StatusCode == 200)
                {
                    return Ok(result);
                }
                else if (result.StatusCode == 404)
                {
                    return NotFound(result);
                }
                else if (result.StatusCode == 406)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, result);
                }
                else
                {
                    return BadRequest(result);
                }
                    
            //}
            //catch (Exception ex)
            //{
            //    return Unauthorized(new ApiResponseDto<string>(401, ex.Message, null));
            //}
        }
    }
}
