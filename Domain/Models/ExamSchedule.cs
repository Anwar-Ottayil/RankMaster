using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // Domain/Models/ExamSchedule.cs
    public class ExamSchedule
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Exam Exam { get; set; }  // Navigation
    }

}
