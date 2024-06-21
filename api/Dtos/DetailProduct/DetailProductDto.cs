using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;

namespace api.Dtos.DetailProduct
{
    public class DetailProductDto
    {
        public int id { get; set; } 
        public string detail { get; set; } = string.Empty;
        public List<ProductDto> products { get; set; }

    }
}