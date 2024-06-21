using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BillInfo
{
    public class CreateBillInfoRequestDto
    {
        [Required]
        [Range(1,10)]
        public int count { get; set; }
        //public string Name { get; set; }
    }
}