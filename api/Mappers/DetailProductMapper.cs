using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DetailProduct;
using api.Models;

namespace api.Mappers
{
    public static class DetailProductMapper
    {
        public static DetailProductDto ToDetailProduct(this DetailProduct detailProduct)
        {
            return new DetailProductDto
            {
                id = detailProduct.id,
                detail = detailProduct.detail
            };
        }
        public static DetailProduct ToDetailProductFromCreateDto(this CreateDetailProductDto model)
        {
            return new DetailProduct
            {
                detail = model.detail
            };
        }
    }
}