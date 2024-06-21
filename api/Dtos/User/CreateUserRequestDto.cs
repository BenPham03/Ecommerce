using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required]
        [MaxLength(280, ErrorMessage = "Email cannot over 280 characters")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters")]
        [MaxLength(16, ErrorMessage = "Password cannot over 16 characters")]
        public string PassWord { get; set; } = string.Empty;
        public Decimal Fund { get; set; }
        [Required]
        [Range(0,3)]
        public int Type { get; set; }
        [Required]
        [MaxLength(280, ErrorMessage = "Username cannot over 280 characters")]
        public string UserName { get; set; } = string.Empty;


    }
}