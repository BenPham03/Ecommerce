using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BillInfo
    {
        public int id { get; set; }
        [Column (TypeName = "int")]
        public int count { get; set; }
        //public string Name { get; set; }
        public int? Billid { get; set; }
        public int? Productid { get; set; }
        public Bill? Bill { get; set; }
        public Product? Product { get; set; }
    }
}