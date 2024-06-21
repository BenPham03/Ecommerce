using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Staff
{
    public class UpdateStaffRequestDto
    {
        [Required]
        [MaxLength(280, ErrorMessage = "Staff name cannot over 280 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(18, 60)]
        public int Age { get; set; }
        [Required]
        [Range(1000000000, 99999999999)]
        public int PhoneNumber { get; set; }
        [Required]
        [MaxLength(280, ErrorMessage = "Address cannot over 280 characters")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(3, ErrorMessage = "Sex cannot over 3 characters")]
        public string Sex { get; set; } = string.Empty;
    }
}