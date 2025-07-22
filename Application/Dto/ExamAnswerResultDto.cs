using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ExamAnswerResultDto
    {
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
