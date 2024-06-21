using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Supplier;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _context;
        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Supplier> CreateAsync(Supplier supplierModel)
        {
            await _context.Supplier.AddAsync(supplierModel);
            await _context.SaveChangesAsync();
            return supplierModel;
        }

        public async Task<Supplier?> DeleteAsync(int id)
        {
            var supplierModel = await _context.Supplier.FirstOrDefaultAsync(x => x.id == id);
            if(supplierModel == null)
            {
                return null;
            }
            _context.Supplier.Remove(supplierModel);
            await _context.SaveChangesAsync();
            return supplierModel;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            
            return await _context.Supplier.Include(c => c.ImportInvoiceInfos).ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return  await _context.Supplier.Include(c=> c.ImportInvoiceInfos).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<bool> SupplierExist(int id)
        {
            return await _context.Supplier.AnyAsync(s => s.id == id);
        }

        public async Task<Supplier?> UpdateAsync(int id, UpdateSupplierRequestDto supplierDto)
        {
            var existingSupplier = await _context.Supplier.FirstOrDefaultAsync(x => x.id == id);
            if(existingSupplier == null)
            {
                return null;
            }

            existingSupplier.name = supplierDto.name;
            existingSupplier.Address = supplierDto.Address;

            await _context.SaveChangesAsync();
            return existingSupplier;
        }
    }
}