using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ExamDto
    {
        public int Id { get; internal set; }
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        public string Description { get; set; }


        public bool IsPaid { get; set; }

        
    }
   

}
