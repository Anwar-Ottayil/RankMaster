using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _repository.GetAllAsync();
                var data = _mapper.Map<List<CategoryDto>>(categories);
                return new ApiResponseDto<List<CategoryDto>>(200, "Categories fetched successfully", data);
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<List<CategoryDto>>(500, $"Server error: {ex.Message}", null);
            }
        }

        public async Task<ApiResponseDto<CategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                var category = await _repository.GetByIdAsync(id);
                if (category == null)
                    return new ApiResponseDto<CategoryDto>(404, "Category not found", null);

                var data = _mapper.Map<CategoryDto>(category);
                return new ApiResponseDto<CategoryDto>(200, "Category fetched successfully", data);
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<CategoryDto>(500, $"Server error: {ex.Message}", null);
            }
        }

        public async Task<ApiResponseDto<int>> CreateAsync(CategoryDto dto)
        {
            try
            {
                var existingCategory = await _repository.FindByNameAsync(dto.Name);
                if (existingCategory != null)
                {
                    return new ApiResponseDto<int>(409, "Category with the same name already exists", 0);
                }

                var category = _mapper.Map<Category>(dto);
                await _repository.AddAsync(category);
                await _repository.SaveChangesAsync();

                return new ApiResponseDto<int>(201, "Category created successfully", category.Id);
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<int>(500, $"Server error: {ex.Message}", 0);
            }
        }
        public async Task<ApiResponseDto<bool>> UpdateAsync(int id, CategoryDto dto)
        {
            try
            {
                var category = await _repository.GetByIdAsync(id);
                if (category == null)
                    return new ApiResponseDto<bool>(404, "Category not found", false);

                category.Name = dto.Name;
                await _repository.UpdateAsync(category);
                await _repository.SaveChangesAsync();

                return new ApiResponseDto<bool>(200, "Category updated successfully", true);
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<bool>(500, $"Server error: {ex.Message}", false);
            }
        }

        public async Task<ApiResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var category = await _repository.GetByIdAsync(id);
                if (category == null)
                    return new ApiResponseDto<bool>(404, "Category not found", false);

                await _repository.DeleteAsync(category);
                await _repository.SaveChangesAsync();

                return new ApiResponseDto<bool>(200, "Category deleted successfully", true);
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<bool>(500, $"Server error: {ex.Message}", false);
            }
        }
    }
}











