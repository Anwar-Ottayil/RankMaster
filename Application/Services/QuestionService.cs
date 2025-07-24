using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<string> UploadQuestionsFromCsvAsync(QuestionCsvUploadDto dto)
        {
            var existingQuestions = await _questionRepository.GetQuestionsByExamIdAsync(dto.ExamId);
            var existingTexts = existingQuestions
                .Select(q => q.Text.Trim().ToLower())
                .ToHashSet();

            var newQuestions = new List<Question>();
            var removedQuestions = new List<RemovedQuestion>();

            using (var stream = new StreamReader(dto.File.OpenReadStream()))
            {
                var header = await stream.ReadLineAsync();

                while (!stream.EndOfStream)
                {
                    var line = await stream.ReadLineAsync();
                    var values = line.Split(',');

                    if (values.Length < 6) continue;

                    var text = values[0].Trim();
                    var optionA = values[1].Trim();
                    var optionB = values[2].Trim();
                    var optionC = values[3].Trim();
                    var optionD = values[4].Trim();
                    var correctOption = values[5].Trim();

                    if (existingTexts.Contains(text.ToLower()))
                    {
                        removedQuestions.Add(new RemovedQuestion
                        {
                            ExamId = dto.ExamId,
                            Text = text,
                            OptionA = optionA,
                            OptionB = optionB,
                            OptionC = optionC,
                            OptionD = optionD,
                            CorrectOption = correctOption,
                            RemovedAt = DateTime.UtcNow
                        });
                        continue;
                    }

                    newQuestions.Add(new Question
                    {
                        ExamId = dto.ExamId,
                        Text = text,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        OptionD = optionD,
                        CorrectOption = correctOption
                    });
                }
            }

            if (newQuestions.Any())
                await _questionRepository.AddQuestionsAsync(newQuestions);

            if (removedQuestions.Any())
                await _questionRepository.AddRemovedQuestionsAsync(removedQuestions);

            return $"Uploaded {newQuestions.Count} questions. Removed {removedQuestions.Count} duplicates.";
        }
    }

}

