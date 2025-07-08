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
    public class SearchRepository : ISearchRepository
    {
        private readonly AppDbContext _context;

        public SearchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> SearchByKeywordAsync(string keyword)
        {
            return await _context.Exams
                .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                .Include(e => e.Category)
                .ToListAsync();
        }
    }
}
