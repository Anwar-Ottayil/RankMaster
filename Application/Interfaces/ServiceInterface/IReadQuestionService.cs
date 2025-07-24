using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IReadQuestionService
    {
        Task<List<QuestionDto>> GetQuestionsByCategoryAndExamAsync(int categoryId, int examId);


        Task<List<ReadQuestionDto>> GetAllQuestionsByExamAsync(int examId);
    }
}
