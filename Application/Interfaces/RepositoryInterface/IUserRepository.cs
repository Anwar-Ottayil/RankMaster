using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<int> GetUserCountAsync();
        Task AddUserAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task UpdateRoleAsync(int userId, string role);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task DeleteAsync(User user);
        Task SaveChangesAsync();
    }
}
