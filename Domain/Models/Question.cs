using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{


    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }

  

 

}
