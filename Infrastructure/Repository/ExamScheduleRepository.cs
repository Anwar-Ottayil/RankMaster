using Application.Interfaces.RepositoryInterface;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    // Infrastructure/Repositories/ExamScheduleRepository.cs
    public class ExamScheduleRepository : IExamScheduleRepository
    {
        private readonly AppDbContext _context;

        public ExamScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExamSchedule schedule)
        {
            await _context.ExamSchedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }
    }

}
