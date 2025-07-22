using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CoordinatorManagementService : ICoordinatorManagementService
    {
        private readonly IUserRepository _userRepo;
        private readonly ICoordinatorCategoryRepository _categoryRepo;

        public CoordinatorManagementService(IUserRepository userRepo, ICoordinatorCategoryRepository categoryRepo)
        {
            _userRepo = userRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task RegisterCoordinatorAsync(CreateCoordinatorDto dto)
        {
            // Check if user already exists
            var existing = await _userRepo.GetByEmailAsync(dto.Email.Trim());
            if (existing != null)
                throw new Exception("User with this email already exists");

            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password ,// hash in real scenarios
                Role = "Coordinator"
            };
            var hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, dto.Password.Trim());
            await _userRepo.AddUserAsync(newUser);

            await _categoryRepo.AssignCategoriesAsync(newUser.Id, dto.CategoryIds);
        }
    }
}
