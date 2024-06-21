using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Dtos.Product
{
    public class ProductDto
    {
         public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public string  ImageURL{get; set;} = string.Empty;
        public int? CategoryId{get;set;}
        public int DetailProductId { get; set; }
        public List<CommentDto> Comments { get; set; }
        
        //navigation property

    }
}