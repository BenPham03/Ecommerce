using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BillInfo
{
    public class BillInfoDto
    {
        public int id { get; set; }
        public int count { get; set; }
        //public string Name { get; set; }
        public int? Billid { get; set; }
        public int? Productid { get; set; }
    }
}