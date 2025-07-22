using Domain.Models;


namespace Application.Interface.ServiceInterface
{
    public interface IExamAttemptService
    {

        Task<IEnumerable<ExamAttempt>> GetAttemptsByUserIdAsync(int userId);
        Task<IEnumerable<ExamAttempt>> GetAttemptsByExamIdAsync(int examId);
        Task AddAttemptAsync(ExamAttempt attempt);
        Task<int> GetTotalScoreByUserIdAsync(int userId);
   



    }
}
