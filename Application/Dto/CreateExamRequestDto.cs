using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateExamRequestDto
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public List<int> QuestionIds { get; set; }

    }
}
