using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoiceInfo;

namespace api.Dtos.ImportInvoice
{
    public class ImportInvoiceDto
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public int status { get; set; }
        public  int? Staffid { get; set; }
        public List<ImportInvoiceInfoDto> ImportInvoiceInfos { get; set; }
    }
}