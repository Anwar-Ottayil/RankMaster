using Application.Dto;
using Application.Interface.RepositoryInterface;
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
    public class ExamServiceIspaid:IExamServiceIspaid
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public ExamServiceIspaid(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
   

        public async Task<IEnumerable<ExamDto>> GetPaidExamsAsync()
        {
            var exams = await _repository.GetPaidExamsAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }

        public async Task<IEnumerable<ExamDto>> GetFreeExamsAsync()
        {
            var exams = await _repository.GetFreeExamsAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }
    }
}
