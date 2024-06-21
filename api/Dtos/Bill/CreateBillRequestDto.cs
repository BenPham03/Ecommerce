using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Bill
{
    public class CreateBillRequestDto
    {
         [Required]
        [Range(1,1000000000)]
        public int TotalPrice { get; set; }
         [Required]
        [Range(0,100)]
        public int Discount { get; set; }

    }
}