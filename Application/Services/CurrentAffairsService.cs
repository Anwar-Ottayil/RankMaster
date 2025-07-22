using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CurrentAffairsService : ICurrentAffairsService
    {
        private readonly ICurrentAffairsRepository _repository;
        private readonly IMapper _mapper;

        public CurrentAffairsService(ICurrentAffairsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CurrentAffairDto>> GetAllCurrentAffairsAsync()
        {
            var affairs = await _repository.GetAllPublicAsync();
            return _mapper.Map<List<CurrentAffairDto>>(affairs);
        }

        public async Task<CurrentAffairDto> AddCurrentAffairAsync(CreateCurrentAffairDto dto)
        {
            var entity = _mapper.Map<CurrentAffair>(dto);
            var saved = await _repository.AddAsync(entity);
            return _mapper.Map<CurrentAffairDto>(saved);
        }
    }
}
