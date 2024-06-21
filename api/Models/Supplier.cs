using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Supplier
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<ImportInvoiceInfo> ImportInvoiceInfos { get; set; } = new List<ImportInvoiceInfo>();
    }
}