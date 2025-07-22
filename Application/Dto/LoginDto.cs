using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter proper Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
 

        public string Password { get; set; }
    }
}
