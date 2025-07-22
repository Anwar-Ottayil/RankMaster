using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class QuestionCsvUploadDto
    {
        public int ExamId { get; set; }


        public int CategoryId { get; set; }



        public IFormFile File { get; set; }
    }
}
