using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>() ;
    }
}