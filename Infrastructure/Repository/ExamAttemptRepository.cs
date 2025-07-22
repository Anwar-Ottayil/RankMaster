using Application.Interface.RepositoryInterface;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ExamAttemptRepository : IExamAttemptRepository
    {
        private readonly AppDbContext _context;

        public ExamAttemptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ExamAttempt> GetByIdAsync(int id)
        {
            return await _context.ExamAttempts
                .Include(e => e.Answers)
                .Include(e => e.Exam)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ExamAttempt>> GetByUserIdAsync(int userId)
        {
            return await _context.ExamAttempts
                .Where(e => e.UserId == userId)
                .Include(e => e.Exam)
                .Include(e => e.Answers)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExamAttempt>> GetByExamIdAsync(int examId)
        {
            return await _context.ExamAttempts
                .Where(e => e.ExamId == examId)
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task AddAsync(ExamAttempt attempt)
        {
            await _context.ExamAttempts.AddAsync(attempt);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamAttempt>> GetAllAsync()
        {
            return await _context.ExamAttempts
                .Include(a => a.Exam)     // Needed for accessing CategoryId
                .Include(a => a.Answers)  // Optional: If you need answers too
                .ToListAsync();
        }
        public async Task<int> GetTotalScoreByUserIdAsync(int userId, int categoryId, int examId)
        {
            return await _context.ExamAttempts
                .Where(a => a.UserId == userId &&
                            a.ExamId == examId &&
                            a.Exam.CategoryId == categoryId)
                .Include(a => a.Exam) // Make sure Exam is included to access CategoryId
                .SumAsync(a => a.Score);
        }
        public async Task<List<ExamAttempt>> GetScoresByExamAndCategoryAsync(int examId, int categoryId)
        {
            return await _context.ExamAttempts
                .Include(e => e.User)
                .Include(e => e.Exam)
                .Where(e => e.ExamId == examId && e.Exam.CategoryId == categoryId)
                .ToListAsync();
        }



    }
}
