using Application.Interfaces.RepositoryInterface;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AppDbContext _context;

        public AnnouncementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> GetPublicAnnouncementsAsync()
        {
            return await _context.Announcements
                .Where(a => a.IsPublic)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<Announcement> AddAnnouncementAsync(Announcement announcement)
        {
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
            return announcement;
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
            await _context.SaveChangesAsync();
            return announcement;
        }

        public async Task<bool> DeleteAnnouncementAsync(int id)
        {
            var existing = await _context.Announcements.FindAsync(id);
            if (existing == null) return false;

            _context.Announcements.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            return await _context.Announcements.FindAsync(id);
        }
    }
}

