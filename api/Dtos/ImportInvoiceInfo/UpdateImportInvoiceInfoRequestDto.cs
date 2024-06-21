using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ImportInvoiceInfo
{
    public class UpdateImportInvoiceInfoRequestDto
    {
        [Required]
        [Range(0,20)]
        public int count { get; set; }
        public int? SupplierID { get; set; }
        public int? ImportInvoiceid { get; set; }
        public int? Productid { get; set; }
    }
}