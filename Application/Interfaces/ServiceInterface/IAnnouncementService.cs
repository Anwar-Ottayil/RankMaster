using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementDto>> GetPublicAnnouncementsAsync();

        Task<AnnouncementDto> AddAnnouncementAsync(CreateAnnouncementDto dto);
        Task<bool> DeleteAnnouncementAsync(int id);
        Task<AnnouncementDto> UpdateAnnouncementAsync(int id, UpdateAnnouncementDto dto);
        Task<AnnouncementDto> GetByIdAsync(int id);
    }
}
