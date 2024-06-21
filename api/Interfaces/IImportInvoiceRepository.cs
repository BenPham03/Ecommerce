using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoice;
using api.Models;

namespace api.Interfaces
{
    public interface IImportInvoiceRepository
    {
        Task<List<ImportInvoice>> GetAllAsync();
        Task<ImportInvoice?> GetByIdAsync(int id);
        Task<ImportInvoice> CreateAsync(ImportInvoice importInvoiceModel);
        Task<ImportInvoice?> UpdateAsync(int id, UpdateImportInvoiceRequestDto importInvoiceDto);
        Task<ImportInvoice?> DeleteAsync(int id);
        Task<bool> ImportInvoiceExist(int id);
    }
}