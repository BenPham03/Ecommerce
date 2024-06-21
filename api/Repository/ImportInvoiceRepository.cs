using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ImportInvoice;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImportInvoiceRepository : IImportInvoiceRepository
    {
        private readonly ApplicationDBContext _context;
        public ImportInvoiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ImportInvoice> CreateAsync(ImportInvoice importInvoiceModel)
        {
            await _context.ImportInvoice.AddAsync(importInvoiceModel);
            await _context.SaveChangesAsync();
            return importInvoiceModel;
        }

        public async Task<ImportInvoice?> DeleteAsync(int id)
        {
            var importInvoiceModel = await _context.ImportInvoice.FirstOrDefaultAsync(x => x.id == id);
            if(importInvoiceModel == null)
            {
                return null;
            }
            _context.ImportInvoice.Remove(importInvoiceModel);
            await _context.SaveChangesAsync();
            return importInvoiceModel;
        }

        public async Task<List<ImportInvoice>> GetAllAsync()
        {
            return await _context.ImportInvoice.Include(c => c.ImportInvoiceInfos).ToListAsync();
        }

        public async Task<ImportInvoice?> GetByIdAsync(int id)
        {
            return await _context.ImportInvoice.Include(c => c.ImportInvoiceInfos).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<bool> ImportInvoiceExist(int id)
        {
            return await _context.ImportInvoice.AnyAsync(s => s.id == id);
        }

        public async Task<ImportInvoice?> UpdateAsync(int id, UpdateImportInvoiceRequestDto importInvoiceDto)
        {
            var existingImportInvoice = await _context.ImportInvoice.FirstOrDefaultAsync(x => x.id == id);
            if(existingImportInvoice == null)
            {
                return null;
            }

            existingImportInvoice.Date = importInvoiceDto.Date;
            existingImportInvoice.status = importInvoiceDto.status;
            existingImportInvoice.Staffid = importInvoiceDto.Staffid;

            await _context.SaveChangesAsync();
            return existingImportInvoice;
        }
    }
}