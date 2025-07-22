using Domain.Models;

namespace Application.Interface.RepositoryInterface
{
    public interface IExamAttemptRepository
    {
        Task<ExamAttempt> GetByIdAsync(int id);
        Task<IEnumerable<ExamAttempt>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ExamAttempt>> GetByExamIdAsync(int examId);
        Task AddAsync(ExamAttempt attempt);
        Task SaveChangesAsync();
        Task<IEnumerable<ExamAttempt>> GetAllAsync();
        Task<int> GetTotalScoreByUserIdAsync(int userId, int categoryId, int examId);
        Task<List<ExamAttempt>> GetScoresByExamAndCategoryAsync(int examId, int categoryId);


    }
}
