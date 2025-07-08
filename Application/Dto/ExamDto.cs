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
        //[Required]
        //public string CategoryName { get; internal set; }
    }
    //public class ExamDto
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public DateTime ScheduledDate { get; set; }
    //    public string CategoryName { get; set; }
    //}

}
