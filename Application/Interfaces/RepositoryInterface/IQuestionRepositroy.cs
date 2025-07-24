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
        Task<List<Question>> GetQuestionsByExamIdAsync(int examId);
        Task AddQuestionsAsync(List<Question> questions);
        Task AddRemovedQuestionsAsync(List<RemovedQuestion> removedQuestions);
        Task<Question> GetByIdAsync(int id);
    }

}
