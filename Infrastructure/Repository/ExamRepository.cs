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
    public class ExamRepository:IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Exam>> GetPaidExamsAsync()
        {
            return await _context.Exams
                .Where(e => e.IsPaid)
                .ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetFreeExamsAsync()
        {
            return await _context.Exams
                .Where(e => !e.IsPaid)
                .ToListAsync();
        }
        public async Task<Exam> GetByIdAsync(int id)
        {
            return await _context.Exams
                .Include(e => e.Category) 
                .FirstOrDefaultAsync(e => e.Id == id);
        }



      
    }
}
