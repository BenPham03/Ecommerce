using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ImportInvoiceInfo
{
    public class CreateImportInvoiceInfoRequestDto
    {
        [Required]
        [Range(0,20)]
        public int count { get; set; }
    }
}