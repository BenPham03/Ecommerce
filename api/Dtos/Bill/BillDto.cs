using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BillInfo;

namespace api.Dtos.Bill
{
    public class BillDto
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public int Discount { get; set; }
        public int? staffid { get;  set;}
        public int? customerId { get; set; }
        public int Status { get; set; }
        public List<BillInfoDto> BillInfos { get; set;}
    }
}