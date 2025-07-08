using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetAllExamsAsync();
        Task<ExamDto> GetExamByIdAsync(int id);
        Task AddExamsAsync(List<ExamDto> examDtos);

        //Task AddExamAsync(ExamDto examDto);
        Task UpdateExamAsync(int id, ExamDto examDto);
        Task DeleteExamAsync(int id);

    }
}
