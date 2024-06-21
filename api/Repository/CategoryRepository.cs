using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Category.AnyAsync(s => s.id == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Category.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Category.FirstOrDefaultAsync(x => x.id == id);
            if (categoryModel == null)
            {
                return null;
            }
            _context.Category.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Category.Include(c => c.Products).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var existingCategory = await _context.Category.FirstOrDefaultAsync(x => x.id == id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.name = categoryDto.name;

            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}