using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterface
{
    public interface ICurrentAffairsRepository
    {
        Task<List<CurrentAffair>> GetAllPublicAsync();


        Task<CurrentAffair> AddAsync(CurrentAffair currentAffair);
    }
}
