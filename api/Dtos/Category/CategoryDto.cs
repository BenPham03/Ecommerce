using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;

namespace api.Dtos.Category
{
    public class CategoryDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public List<ProductDto> Products { get; set;}
    }
}