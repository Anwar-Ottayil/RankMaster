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
    public class ExamService : IExamService
    {
        private readonly IRepository<Exam> _repository;
        private readonly IMapper _mapper;

        public ExamService(IRepository<Exam> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExamsAsync()
        {
            var exams = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }

        public async Task<ExamDto> GetExamByIdAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExamDto>(exam);
        }
        public async Task AddExamsAsync(List<ExamDto> examDtos)
        {
            if (examDtos == null || !examDtos.Any())
                throw new ArgumentException("No exams to add.");

            var exams = _mapper.Map<List<Exam>>(examDtos);

            // If your repository supports bulk insert, use it:
            await _repository.AddRangeAsync(exams);

            // Otherwise, loop insert
            //foreach (var exam in exams)
            //{
            //    await _repository.AddAsync(exam);
            //}
        }

        public async Task UpdateExamAsync(int id, ExamDto examDto)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null) throw new Exception("Exam not found");

            _mapper.Map(examDto, exam);
            await _repository.UpdateAsync(exam);
        }

        public async Task DeleteExamAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null) throw new Exception("Exam not found");

            await _repository.DeleteAsync(exam);
        }
    }

}
