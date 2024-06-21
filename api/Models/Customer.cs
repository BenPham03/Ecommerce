using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column (TypeName = "int")]
        public int Age { get; set; }
        [Column (TypeName = "int")]
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        //public int MyProperty { get; set; }
        public List<Bill> Bills { get; set; } = new List<Bill> ();
        public List<Users> Users { get; set; } =  new List<Users> ();
    }
}