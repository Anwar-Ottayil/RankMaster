using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Category Category { get; set; }
        public ICollection<Question>Questions { get; set; }
        public int? CategoryId { get; set; }
 

    }


}
