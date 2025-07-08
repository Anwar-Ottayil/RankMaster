using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface IQuestionRepository
    {
        //Task AddRangeAsync(List<Question> questions);
        //Task<bool> ExamExistsAsync(int examId);



        //Task GetQuestionsByCategoryAndExamAsync(int categoryId, int examId);
        //Task<bool> ExamExistsAsync(int examId);


        //Task<List<Question>> GetQuestionsByExamIdAsync(int examId);
        //Task DeleteQuestionsByExamIdAsync(int examId);
        //Task AddRemovedQuestionLogsAsync(List<RemovedQuestionLog> logs);
        Task<List<Question>> GetQuestionsByExamIdAsync(int examId);
        Task AddQuestionsAsync(List<Question> questions);
        Task AddRemovedQuestionsAsync(List<RemovedQuestion> removedQuestions);
    }

}
