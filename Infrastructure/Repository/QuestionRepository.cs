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
    //public class QuestionRepository : IQuestionRepository
    //{
    //    private readonly AppDbContext _context;

    //    public QuestionRepository(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task AddRangeAsync(List<Question> questions)
    //    {
    //        await _context.Questions.AddRangeAsync(questions);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<bool> ExamExistsAsync(int examId)
    //    {
    //        return await _context.Exams.AnyAsync(e => e.Id == examId);
    //    }
    //}






    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Exam) // optional: if you need exam info
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Question>> GetQuestionsByExamIdAsync(int examId)
        {
            return await _context.Questions
                .Where(q => q.ExamId == examId)
                .ToListAsync();
        }

        public async Task AddQuestionsAsync(List<Question> questions)
        {
            _context.Questions.AddRange(questions);
            await _context.SaveChangesAsync();
        }

        public async Task AddRemovedQuestionsAsync(List<RemovedQuestion> removedQuestions)
        {
            _context.RemovedQuestions.AddRange(removedQuestions);
            await _context.SaveChangesAsync();
        }
    }
}
