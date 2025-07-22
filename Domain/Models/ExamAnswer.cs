namespace Domain.Models
{
    public class ExamAnswer
    {
        public int Id { get; set; }

        public int ExamAttemptId { get; set; }
        public ExamAttempt ExamAttempt { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string SelectedOption { get; set; }
        public bool IsCorrect { get; set; }



     
    }

}
