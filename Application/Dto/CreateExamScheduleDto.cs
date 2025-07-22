using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    // Application/DTOs/ExamScheduleDto.cs
    public class CreateExamScheduleDto
    {
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
