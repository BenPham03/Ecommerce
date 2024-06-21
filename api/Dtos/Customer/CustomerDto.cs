using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bill;
using api.Models;

namespace api.Dtos.Customer
{
    public class CustomerDto
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public List<BillDto> Bills { get; set; }
        public List<Users> users { get; set; }
    }
}