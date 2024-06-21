using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Bill
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        [Column (TypeName = "int")]
        public int TotalPrice { get; set; }
        [Column (TypeName = "int")]
        public int Discount { get; set; }
        
        public Staff? staff { get; set; }
        public int? staffid {get;  set;}
        public Customer? customer { get; set; }
        public int? customerId { get; set; }
        public List<BillInfo> BillInfos { get; set; } = new List<BillInfo>();
        public int Status { get; set; }

    }
}