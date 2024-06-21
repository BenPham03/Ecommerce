using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ImportInvoice
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        [Column (TypeName ="int")]
        public int status { get; set; }
        public Staff? Staff { get; set; }
        public  int? Staffid {  get; set; }


        public List<ImportInvoiceInfo> ImportInvoiceInfos { get; set; } = new List<ImportInvoiceInfo>();
    }
}