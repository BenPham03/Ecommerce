using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoiceInfo;

namespace api.Dtos.Supplier
{
    public class SupplierDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<ImportInvoiceInfoDto> ImportInvoiceInfos { get; set; }
    }
}