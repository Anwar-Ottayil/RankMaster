using Application.Dto;

namespace Application.Interfaces.ServiceInterface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
