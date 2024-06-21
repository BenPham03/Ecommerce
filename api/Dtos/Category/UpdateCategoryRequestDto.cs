using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage ="Category name cannot over 100 characters")]
        public string name { get; set; } = string.Empty;
    }
}