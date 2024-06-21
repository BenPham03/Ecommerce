using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public  static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto (this Category categoryModel )
        {
            return new CategoryDto
            {
                id = categoryModel.id,
                name = categoryModel.name,
                Products = categoryModel.Products.Select(c => c.ToProductDto()).ToList()
            };
        }
        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                name = categoryDto.name
            };
        }
    }
}