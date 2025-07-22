using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{

    public class ExamAttemptResultDto
    {
        public int AttemptId { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public DateTime AttemptedAt { get; set; }
        public int Score { get; set; }
        public List<ExamAnswerResultDto> Answers { get; set; }
    }
}
