using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IExamServiceIspaid
    {
        Task<IEnumerable<ExamDto>> GetPaidExamsAsync();
        Task<IEnumerable<ExamDto>> GetFreeExamsAsync();
    }
}
