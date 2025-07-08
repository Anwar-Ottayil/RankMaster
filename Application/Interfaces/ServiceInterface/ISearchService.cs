using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface ISearchService
    {
        Task<List<SearchDto>> SearchExamsAsync(string keyword);
    }
}
