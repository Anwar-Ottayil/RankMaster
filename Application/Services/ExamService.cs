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
        private readonly INotificationService _notificationService;

        public ExamService(IRepository<Exam> repository, IMapper mapper, INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationService = notificationService;
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

            await _repository.AddRangeAsync(exams);

            await _notificationService.SendNotificationToAll(
                "New Exams Added",
                $"{exams.Count} new exam(s) have been added. Check them out now!"
            );
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
        public async Task<PagedResultDto<ExamDto>> GetPaginatedExamsAsync(int pageNumber, int pageSize)
        {
            var allExams = await _repository.GetAllAsync();
            var totalCount = allExams.Count();

            var pagedExams = allExams
                .OrderByDescending(e => e.CreatedAt) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResultDto<ExamDto>
            {
                Items = _mapper.Map<IEnumerable<ExamDto>>(pagedExams),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<int> CreateExamAsync(CreateExamRequestDto dto)
        {
            var exam = new Exam
            {
                Title = dto.Title,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            exam = await _repository.AddExamAsync(exam);

            var questionIds = dto.QuestionIds.Distinct().ToList();

            var examQuestions = questionIds.Select(qid => new ExamQuestion
            {
                ExamId = exam.Id,
                QuestionId = qid
            }).ToList();

            await _repository.AddExamQuestionsAsync(examQuestions);

            return exam.Id;
        }

    }

}
