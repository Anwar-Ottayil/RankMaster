using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateAnnouncementDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsPublic { get; set; }
    }
}
