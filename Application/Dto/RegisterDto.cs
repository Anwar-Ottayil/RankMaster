using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(100)]

        public string? Name { get; set; }

        [Required, MaxLength(100)]
        [EmailAddress(ErrorMessage = "Enter proper Email")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one letter, one number, and one special character.")]
        public string? Password { get; set; }


        [Required]
        [Compare("Password", ErrorMessage = "password and confirmation password do not match.")]
        public string? ConformPassword { get; set; }
    }
}
