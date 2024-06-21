using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BillInfo;
using api.Models;

namespace api.Interfaces
{
    public interface IBillInfoRepository
    {
        Task<List<BillInfo>> GetAllAsync();
        Task<BillInfo?> GetByIdAsync(int id);
        Task<BillInfo> CreateAsync(BillInfo billInfoModel);
        Task<BillInfo?> UpdateAsync(int id, UpdateBillInfoRequestDto billInfoDto);
        Task<BillInfo?> DeleteAsync(int id);
    }
}