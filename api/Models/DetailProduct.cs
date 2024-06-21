using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DetailProduct
    {
        public int id { get; set; }
        
        public string detail { get; set; } = string.Empty;
        public List<Product> comments { get; set; } = new List<Product>();

    }
}