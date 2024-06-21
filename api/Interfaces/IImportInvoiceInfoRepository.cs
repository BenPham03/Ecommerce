using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoiceInfo;
using api.Models;

namespace api.Interfaces
{
    public interface IImportInvoiceInfoRepository
    {
        Task<List<ImportInvoiceInfo>> GetAllAsync();
        Task<ImportInvoiceInfo?> GetByIdAsync(int id);
        Task<ImportInvoiceInfo> CreateAsync(ImportInvoiceInfo importInvoiceInfoModel);
        Task<ImportInvoiceInfo?> UpdateAsync(int id, UpdateImportInvoiceInfoRequestDto importInvoiceInfoDto);
        Task<ImportInvoiceInfo?> DeleteAsync(int id);
    }
}