using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bill;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDBContext  _context;
        public BillRepository(ApplicationDBContext context)
        {
            _context =  context;
        }

        public async Task<bool> BillExists(int id)
        {
            return await _context.Bill.AnyAsync(s=> s.id == id);
        }

        public async Task<Bill> CreateAsync(Bill billModel)
        {
            await _context.Bill.AddAsync(billModel);
            await _context.SaveChangesAsync();
            return billModel;
        }

        public async Task<Bill?> DeleteAsync(int id)
        {
            var billModel = await _context.Bill.FirstOrDefaultAsync(x => x.id == id);
            if(billModel == null)
            {
                return null;
            }
            _context.Bill.Remove(billModel);
            await _context.SaveChangesAsync();
            return billModel;
        }

        public async Task<List<Bill>> GetAllAsync()
        {
            return await _context.Bill.Include(c => c.BillInfos).ToListAsync();
        }

        public async Task<Bill?> GetByIdAsync(int id)
        {
            return await _context.Bill.Include(c=> c.BillInfos).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Bill?> UpdateAsync(int id, UpdateBillRequestDto billDto)
        {
            var existingBill = await _context.Bill.FirstOrDefaultAsync(x => x.id == id);
            if(existingBill == null)
            {
                return null;
            }

            existingBill.Date = billDto.Date;
            existingBill.TotalPrice= billDto.TotalPrice;
            existingBill.Discount =  billDto.Discount;
            existingBill.staffid =  billDto.staffid;
            existingBill.customerId = billDto.customerId;

            await _context.SaveChangesAsync();
            return existingBill;
        }
    }
}