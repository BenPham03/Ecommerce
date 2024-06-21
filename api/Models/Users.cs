using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        [Column (TypeName ="Decimal(18,2)")]  // Decimal
        public Decimal Fund { get; set; }
        [Column (TypeName ="int")]  // Decimal
        public int Type { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } =  new List<Comment>();
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}