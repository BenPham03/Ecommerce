using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ImportInvoiceInfo
    {
        public int id { get; set; }
        [Column (TypeName ="int")]
        public int count { get; set; }
        public int? SupplierID { get; set; }
        public int? ImportInvoiceid { get; set; }
        public int? Productid { get; set; }
        public Supplier? Supplier { get; set; }
        public ImportInvoice? ImportInvoice { get; set; }
        public Product? Product { get; set; }
    }
}