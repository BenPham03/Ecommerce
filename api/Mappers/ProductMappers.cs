using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new  ProductDto
            {
                id = productModel.id,
                Name = productModel.Name,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                Status  = productModel.Status,
                ImageURL = productModel.ImageURL,
                CategoryId  = productModel.CategoryId,
                DetailProductId = productModel.DetailProductId,
                Comments = productModel.comments.Select(x => x.ToCommentDto()).ToList()
            };
        }
        public static Product ToProductFromCreateDto(this CreateProductRequestDto productDto, int CategoryId)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Status  = productDto.Status,
                ImageURL = productDto.ImageURL,
                CategoryId  = CategoryId,
            };
        }
    }
}