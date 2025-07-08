using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface ICoordinatorCategoryRepository
    {
        Task AssignCategoriesAsync(int coordinatorId, List<int> categoryIds);
        Task<List<int>> GetCategoryIdsByCoordinatorAsync(int coordinatorId);
    }
}
