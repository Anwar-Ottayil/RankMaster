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
    public class ReadQuestionService : IReadQuestionService
    {
        private readonly IReadQuestionRepository _repository;
        private readonly IMapper _mapper;

        public ReadQuestionService(IReadQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<QuestionDto>> GetQuestionsByCategoryAndExamAsync(int categoryId, int examId)
        {
            var questions = await _repository.GetQuestionsByCategoryAndExamAsync(categoryId, examId);
            return _mapper.Map<List<QuestionDto>>(questions);
        }
    }
}
