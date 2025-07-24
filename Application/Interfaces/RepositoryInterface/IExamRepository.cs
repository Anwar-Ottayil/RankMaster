using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetPaidExamsAsync();
        Task<IEnumerable<Exam>> GetFreeExamsAsync();
        Task<Exam> GetByIdAsync(int id);
        
    }
}
