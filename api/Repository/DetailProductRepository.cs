using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DetailProduct;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DetailProductRepository  : IDetailProductRepository
    {
        private readonly ApplicationDBContext _context;
        public DetailProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DetailProduct> CreateAsync(DetailProduct model)
        {
            await _context.DetailProduct.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<DetailProduct?> DeleteAsync(int id)
        {
            var DetailProductModel = await _context.DetailProduct.FirstOrDefaultAsync(c => c.id == id);
            if(DetailProductModel == null)
            {
                return null;
            }
            _context.DetailProduct.Remove(DetailProductModel);
            await _context.SaveChangesAsync();
            return DetailProductModel;
        }

        public async Task<bool> DetailProductExist(int id)
        {
            return await _context.DetailProduct.AnyAsync(s=> s.id == id);
        }

        public async Task<List<DetailProduct>> GetAllAsync()
        {
            return await _context.DetailProduct.ToListAsync();
        }

        public async Task<DetailProduct?> GetByIdAsync(int id)
        {
            return await _context.DetailProduct.FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<DetailProduct?> UpdateAsync(int id, UpdateDetailProductRequest model)
        {
            var existingDetail = await _context.DetailProduct.FirstOrDefaultAsync(i => i.id == id);
            if(existingDetail == null)
            {
                return null;
            }

            existingDetail.detail = model.detail;
            await _context.SaveChangesAsync();
            return existingDetail;
        }
    }
}