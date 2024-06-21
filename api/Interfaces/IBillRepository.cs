using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bill;
using api.Models;

namespace api.Interfaces
{
    public interface IBillRepository
    {
        Task<List<Bill>> GetAllAsync();
        Task<Bill?> GetByIdAsync(int id);
        Task<Bill> CreateAsync(Bill billModel);
        Task<Bill?> UpdateAsync(int id, UpdateBillRequestDto billDto);
        Task<Bill?> DeleteAsync(int id);
        Task<bool> BillExists(int id);
    }
}