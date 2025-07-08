using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{

    public interface ICategoryService
    {
        Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync();
        Task<ApiResponseDto<CategoryDto>> GetByIdAsync(int id);
        Task<ApiResponseDto<int>> CreateAsync(CategoryDto dto);
        Task<ApiResponseDto<bool>> UpdateAsync(int id, CategoryDto dto);
        Task<ApiResponseDto<bool>> DeleteAsync(int id);
    }
}
