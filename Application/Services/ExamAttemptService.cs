using Application.Interface.RepositoryInterface;
using Application.Interface.ServiceInterface;
using Domain.Models;

namespace Application.Service
{
    public class ExamAttemptService : IExamAttemptService
    {
        private readonly IExamAttemptRepository _repository;

        public ExamAttemptService(IExamAttemptRepository repository)
        {
            _repository = repository;
        }

    
        public async Task<IEnumerable<ExamAttempt>> GetAttemptsByUserIdAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ExamAttempt>> GetAttemptsByExamIdAsync(int examId)
        {
            return await _repository.GetByExamIdAsync(examId);
        }

        public async Task AddAttemptAsync(ExamAttempt attempt)
        {
            await _repository.AddAsync(attempt);
            await _repository.SaveChangesAsync();
        }

        public async Task<int> GetTotalScoreByUserIdAsync(int userId)
        {
            var attempts = await _repository.GetByUserIdAsync(userId);
            return attempts.Sum(a => a.Score);
        }



    }
}
