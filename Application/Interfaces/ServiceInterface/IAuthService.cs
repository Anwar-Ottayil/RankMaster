using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IAuthService
    {
        Task<ApiResponseDto<AuthResponseDto>> Login(LoginDto login);
        Task<ApiResponseDto<AuthResponseDto>> Register(RegisterDto register);
    }
}
