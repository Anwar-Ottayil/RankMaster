using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public AnnouncementService(
            IAnnouncementRepository repository,
            IMapper mapper,
            INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<List<AnnouncementDto>> GetPublicAnnouncementsAsync()
        {
            var list = await _repository.GetPublicAnnouncementsAsync();
            return _mapper.Map<List<AnnouncementDto>>(list);
        }

        public async Task<AnnouncementDto> AddAnnouncementAsync(CreateAnnouncementDto dto)
        {
            var announcement = _mapper.Map<Announcement>(dto);
            announcement.CreatedAt = DateTime.UtcNow;

            var created = await _repository.AddAnnouncementAsync(announcement);
            var announcementDto = _mapper.Map<AnnouncementDto>(created);

            string title = "📢 New Announcement";
            string message = $"{announcement.Title}";

            await _notificationService.SendNotificationToAll(title, message);

            return announcementDto;
        }

        public async Task<bool> DeleteAnnouncementAsync(int id)
        {
            return await _repository.DeleteAnnouncementAsync(id);
        }

        public async Task<AnnouncementDto> UpdateAnnouncementAsync(int id, UpdateAnnouncementDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAnnouncementAsync(existing);
            return _mapper.Map<AnnouncementDto>(updated);
        }

        public async Task<AnnouncementDto> GetByIdAsync(int id)
        {
            var announcement = await _repository.GetByIdAsync(id);
            return _mapper.Map<AnnouncementDto>(announcement);
        }
    }
}
