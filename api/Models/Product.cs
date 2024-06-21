using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "float")]
        public float Price { get; set; }
        [Column(TypeName = "int")]
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public int DetailProductId { get; set; }
        public DetailProduct? DetailProduct { get; set; }
        //navigation property
        public Category? Category { get; set; }
        public List<Comment> comments { get; set; } = new List<Comment>();

    }
}