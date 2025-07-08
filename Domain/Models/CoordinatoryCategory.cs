using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CoordinatorCategory
    {
        public int Id { get; set; }
        public int CoordinatorId { get; set; }
        public int CategoryId { get; set; }
        public User Coordinator { get; set; }
        public Category Category { get; set; }
    }
}
