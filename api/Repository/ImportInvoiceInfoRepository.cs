using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ImportInvoiceInfo;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImportInvoiceInfoRepository : IImportInvoiceInfoRepository
    {
        private readonly ApplicationDBContext _context;
        public ImportInvoiceInfoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ImportInvoiceInfo> CreateAsync(ImportInvoiceInfo importInvoiceInfoModel)
        {
            await _context.ImportInvoiceInfo.AddAsync(importInvoiceInfoModel);
            await _context.SaveChangesAsync();
            return importInvoiceInfoModel;
        }

        public async Task<ImportInvoiceInfo?> DeleteAsync(int id)
        {
            var importInvoiceInfoModel = await _context.ImportInvoiceInfo.FirstOrDefaultAsync(x => x.id == id);
            if(importInvoiceInfoModel == null)
            {
                return null;
            }
            _context.ImportInvoiceInfo.Remove(importInvoiceInfoModel);
            await _context.SaveChangesAsync();
            return importInvoiceInfoModel;
        }

        public async Task<List<ImportInvoiceInfo>> GetAllAsync()
        {
            return await _context.ImportInvoiceInfo.ToListAsync();
        }

        public async Task<ImportInvoiceInfo?> GetByIdAsync(int id)
        {
            return await _context.ImportInvoiceInfo.FindAsync(id);
        }

        public async Task<ImportInvoiceInfo?> UpdateAsync(int id, UpdateImportInvoiceInfoRequestDto importInvoiceInfoDto)
        {
            var existingImportInfo = await _context.ImportInvoiceInfo.FirstOrDefaultAsync(x => x.id == id);
            if(existingImportInfo == null)
            {
                return null;
            }

            existingImportInfo.count = importInvoiceInfoDto.count;
            existingImportInfo.SupplierID = importInvoiceInfoDto.SupplierID;
            existingImportInfo.ImportInvoiceid = importInvoiceInfoDto.ImportInvoiceid;
            existingImportInfo.Productid = importInvoiceInfoDto.Productid;

            await _context.SaveChangesAsync();
            return existingImportInfo;
        }
    }
}