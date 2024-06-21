using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Staff
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column (TypeName = "INT")]  //
        public int Age { get; set; }
        [Column (TypeName = "INT")]  //
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public List<Bill> Bills { get; set; } = new  List<Bill> ();
        public List<ImportInvoice> ImportInvoices { get; set; }  = new List<ImportInvoice>();
    }
}