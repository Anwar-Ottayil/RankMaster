using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _repository;
        private readonly IMapper _mapper;

        public SearchService(ISearchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SearchDto>> SearchExamsAsync(string keyword)
        {
            var exams = await _repository.SearchByKeywordAsync(keyword);
            return exams.Select(e => new SearchDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                CategoryName = e.Category?.Name ?? ""
            }).ToList();
        }
    }
}
