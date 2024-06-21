using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Product.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Product.FirstOrDefaultAsync(c => c.id == id);
            if (productModel == null)
            {
                return null;
            }
            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {
            var products = _context.Product.Include(c => c.comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                products = products.Where(s => s.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    products = query.IsDecsending ? products.OrderByDescending(S => S.Name) : products.OrderBy(S => S.Name);

                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize; 

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Product.Include(c => c.comments).FirstOrDefaultAsync(i => i.id == id);


        }

        public Task<bool> ProductExists(int id)
        {
            return _context.Product.AnyAsync(s => s.id == id);
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto)
        {
            var existingProduct = await _context.Product.FirstOrDefaultAsync(c => c.id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Quantity = productDto.Quantity;
            existingProduct.Status = productDto.Status;
            existingProduct.ImageURL = productDto.ImageURL;
            existingProduct.CategoryId = productDto.CategoryId;

            await _context.SaveChangesAsync();
            return existingProduct;

        }
    }
}