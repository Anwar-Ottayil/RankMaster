using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetPublicAnnouncementsAsync();


        Task<Announcement> AddAnnouncementAsync(Announcement announcement);
        Task<bool> DeleteAnnouncementAsync(int id);
        Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
        Task<Announcement> GetByIdAsync(int id);
    }
}
