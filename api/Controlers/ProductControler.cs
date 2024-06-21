using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/product")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductControler(ApplicationDBContext context, IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _context = context;
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await _productRepo.GetAllAsync(query);
            var productDto = products.Select(s => s.ToProductDto());
            // Console.WriteLine(product);
            return Ok(productDto);
        }
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        [HttpGet("ByName{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Product.FirstOrDefaultAsync(p => p.Name == name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto ,[FromRoute] int categoryId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _categoryRepo.CategoryExists(categoryId))
            {
                return BadRequest("Category is not exist");
            }
            var productModel = productDto.ToProductFromCreateDto(categoryId);
            await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(GetById), new { id = productModel.id }, productModel.ToProductDto());
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateProductRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var productModel = await _productRepo.UpdateAsync(id, updateDto);
            if (productModel == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return Ok(productModel.ToProductDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var productModel = await _productRepo.DeleteAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}