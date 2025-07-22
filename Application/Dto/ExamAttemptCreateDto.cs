using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ExamAttemptCreateDto
    {
        public int ExamId { get; set; }     
        public List<ExamAnswerDto> Answers { get; set; }
    }
}
