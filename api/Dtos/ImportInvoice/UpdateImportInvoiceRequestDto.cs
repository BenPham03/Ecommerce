using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ImportInvoice
{
    public class UpdateImportInvoiceRequestDto
    {
        public DateTime Date { get; set; }
        [Required]
        [Range(0,1)]
        public int status { get; set; }
        public  int? Staffid {  get; set; }
    }
}