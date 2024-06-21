using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ImportInvoice
{
    public class CreateImportInvoiceRequestDto
    {
        // public DateTime Date { get; set; }
        [Required]
        [Range(0,3)]
        public int status { get; set; }
    }
}