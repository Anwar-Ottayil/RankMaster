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
    public class ReadQuestionRepository : IReadQuestionRepository
    {
 

    private readonly AppDbContext _context;

    public ReadQuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetQuestionsByExamIdAsync(int examId)
    {
        return await _context.Questions
            .Where(q => q.ExamId == examId)
            .ToListAsync();
    }

    public async Task<List<RemovedQuestion>> GetRemovedQuestionsByExamIdAsync(int examId)
    {
        return await _context.RemovedQuestions
            .Where(q => q.ExamId == examId)
            .ToListAsync();
    }
        public async Task<List<Question>> GetQuestionsByCategoryAndExamAsync(int categoryId, int examId)
        {
            return await _context.Questions
                .Include(q => q.Exam)
                .Where(q => q.ExamId == examId && q.Exam.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
