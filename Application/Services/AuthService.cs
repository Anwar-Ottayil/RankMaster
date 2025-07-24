using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IRepository<User> repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<AuthResponseDto>> Register(RegisterDto register)
        {

            try
            {



                var exist = (await _repository.GetAllAsync()).FirstOrDefault(e => e.Email.ToLower().Trim() == register.Email.ToLower());
                if (exist != null) return new ApiResponseDto<AuthResponseDto>(400, "User already exist");

                var mapped = _mapper.Map<User>(register);

                var HashPassword = new PasswordHasher<User>();
                mapped.Password = HashPassword.HashPassword(mapped, register.Password);

                await _repository.AddAsync(mapped);
                return new ApiResponseDto<AuthResponseDto>(200, "User Registered successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<AuthResponseDto>(500, "something went wrong" + ex.Message);
            }



        }
        public async Task<ApiResponseDto<AuthResponseDto>> Login(LoginDto login)
        {


       
                var isexist = (await _repository.GetAllAsync()).FirstOrDefault(e => e.Email.ToLower() == login.Email.ToLower());
                if (isexist == null) return new ApiResponseDto<AuthResponseDto>(404, "Not Found");

                var HashPassword = new PasswordHasher<User>();
                var result = HashPassword.VerifyHashedPassword(isexist, isexist.Password, login.Password);
                if (result == PasswordVerificationResult.Failed) return new ApiResponseDto<AuthResponseDto>(406, "Incorrect password");

                var Token = GenerateJwtToken(isexist);

                var obj = new AuthResponseDto { Name = isexist.Name, Role = isexist.Role, Token = Token };
                return new ApiResponseDto<AuthResponseDto>(200, "Login successfully", obj);
         


        }


        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
    
