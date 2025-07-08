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
    public class CoordinatorCategoryRepository : ICoordinatorCategoryRepository
    {
        private readonly AppDbContext _context;

        public CoordinatorCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignCategoriesAsync(int coordinatorId, List<int> categoryIds)
        {
            var existing = _context.CoordinatorCategories
                .Where(cc => cc.CoordinatorId == coordinatorId);

            _context.CoordinatorCategories.RemoveRange(existing);

            var newAssignments = categoryIds.Select(id => new CoordinatorCategory
            {
                CoordinatorId = coordinatorId,
                CategoryId = id
            }).ToList();

            await _context.CoordinatorCategories.AddRangeAsync(newAssignments);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetCategoryIdsByCoordinatorAsync(int coordinatorId)
        {
            return await _context.CoordinatorCategories
                .Where(cc => cc.CoordinatorId == coordinatorId)
                .Select(cc => cc.CategoryId)
                .ToListAsync();
        }
    }
}
