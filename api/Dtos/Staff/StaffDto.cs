using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bill;
using api.Dtos.ImportInvoice;

namespace api.Dtos.Staff
{
    public class StaffDto
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public List<BillDto> Bills { get; set; }
        public List<ImportInvoiceDto> ImportInvoices { get; set; }
    }
}