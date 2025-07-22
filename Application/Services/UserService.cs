using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(_mapper.Map<UserDto>);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;

            await _repository.DeleteAsync(user);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
