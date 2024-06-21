using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Supplier
{
    public class CreateSupplierRequestDto
    {
        [Required]
        [MaxLength(280, ErrorMessage = "Supplier name cannot over 280 characters")]
        public string name { get; set; } = string.Empty;
        [Required]
        [MaxLength(280, ErrorMessage = "Address cannot over 280 characters")]
        public string Address { get; set; } = string.Empty;
    }
}