using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace api.Controlers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ApplicationDBContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var Category = await _categoryRepo.GetAllAsync();
            var CategoryDto = Category.Select(c => c.ToCategoryDto());
            return Ok(Category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound();
            else return  Ok(category.ToCategoryDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.id }, categoryModel.ToCategoryDto());
        }
        [HttpPut]
        [Route( "update/{id}" )]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateCategoryRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.UpdateAsync(id, updateDto);
            if(categoryModel == null)
            {
                return NotFound();
            }
            
            await  _context.SaveChangesAsync();
            return Ok(categoryModel.ToCategoryDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var categoryModel = await _categoryRepo.DeleteAsync(id);
            if(categoryModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}