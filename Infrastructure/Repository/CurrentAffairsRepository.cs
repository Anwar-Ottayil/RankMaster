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
    public class CurrentAffairsRepository : ICurrentAffairsRepository
    {
        private readonly AppDbContext _context;

        public CurrentAffairsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentAffair>> GetAllPublicAsync()
        {
            return await _context.CurrentAffairs
                .Where(c => c.IsPublic)
                .OrderByDescending(c => c.PublishedDate)
                .ToListAsync();
        }

        public async Task<CurrentAffair> AddAsync(CurrentAffair currentAffair)
        {
            _context.CurrentAffairs.Add(currentAffair);
            await _context.SaveChangesAsync();
            return currentAffair;
        }
    }
}
