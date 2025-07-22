using Application.Dto;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamScheduleService : IExamScheduleService
    {
        private readonly IExamScheduleRepository _scheduleRepository;

        public ExamScheduleService(IExamScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<bool> CreateScheduleAsync(CreateExamScheduleDto dto)
        {
            var schedule = new ExamSchedule
            {
                ExamId = dto.ExamId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            await _scheduleRepository.AddAsync(schedule);
            return true;
        }
    }
}
