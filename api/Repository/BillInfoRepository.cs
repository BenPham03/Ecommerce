using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.BillInfo;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BillInfoRepository : IBillInfoRepository
    {
        private readonly ApplicationDBContext _context;
        public BillInfoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<BillInfo> CreateAsync(BillInfo billInfoModel)
        {
            await _context.BillInfo.AddAsync(billInfoModel);
            await _context.SaveChangesAsync();
            return billInfoModel;
        }

        public async Task<BillInfo?> DeleteAsync(int id)
        {
            var billInfoModel = await _context.BillInfo.FirstOrDefaultAsync(x => x.id == id);
            if(billInfoModel == null)
            {
                return null;
            }
            _context.BillInfo.Remove(billInfoModel);
            await _context.SaveChangesAsync();
            return billInfoModel;
        }

        public async Task<List<BillInfo>> GetAllAsync()
        {
            return await _context.BillInfo.ToListAsync();
        }

        public async Task<BillInfo?> GetByIdAsync(int id)
        {
            return await _context.BillInfo.FindAsync(id);
        }

        public async Task<BillInfo?> UpdateAsync(int id, UpdateBillInfoRequestDto billInfoDto)
        {
            var existingBillInfo = await _context.BillInfo.FirstOrDefaultAsync(x => x.id == id);
            if(existingBillInfo == null)
            {
                return null;
            }

            existingBillInfo.count = billInfoDto.count;
            existingBillInfo.Billid= billInfoDto.Billid;
            existingBillInfo.Productid =  billInfoDto.Productid;

            await _context.SaveChangesAsync();
            return existingBillInfo;
        }
    }
}