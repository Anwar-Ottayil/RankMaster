using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ExamAttempt
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int UserId { get; set; } // Assuming User table exists
        public User User { get; set; }

        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

        public int Score { get; set; }

        public ICollection<ExamAnswer> Answers { get; set; }
    }
}
