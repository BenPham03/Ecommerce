using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MaxLength(280, ErrorMessage ="Product name cannot over 280 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0,200000000)]
        public float Price { get; set; }
        [Required]
        [Range(0,10000)]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage ="Status cannot over 15 characters")]
        public string Status { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage ="ImageURL cannot over 100 characters")]
        public string  ImageURL{get; set;} = string.Empty;
        public int? CategoryId{get;set;}
    }
}