using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ImportInvoiceInfo
{
    public class ImportInvoiceInfoDto
    {
        public int id { get; set; }
        public int count { get; set; }
        public int? SupplierID { get; set; }
        public int? ImportInvoiceid { get; set; }
        public int? Productid { get; set; }

    }
}