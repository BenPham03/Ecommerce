using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Staff;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDBContext _context;
        public StaffRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Staff> CreateAsync(Staff staffModel)
        {
            await _context.Staff.AddAsync(staffModel);
            await _context.SaveChangesAsync();
            return staffModel;
        }

        public async Task<Staff?> DeleteAsync(int id)
        {
            var staffModel = await _context.Staff.FirstOrDefaultAsync(x => x.id == id);
            if(staffModel == null)
            {
                return null;
            }
            _context.Staff.Remove(staffModel);
            await _context.SaveChangesAsync();
            return staffModel;
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _context.Staff.Include(c=> c.Bills).Include(c => c.ImportInvoices).ToListAsync();
        }

        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _context.Staff.Include(c => c.Bills).Include(c=> c.ImportInvoices).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<bool> StaffExist(int staffid)
        {
            return await _context.Staff.AnyAsync(s=> s.id == staffid);
        }

        public async Task<Staff?> UpdateAsync(int id, UpdateStaffRequestDto staffDto)
        {
            var existingStaff = await _context.Staff.FirstOrDefaultAsync(x => x.id == id);
            if(existingStaff == null)
            {
                return null;
            }

            existingStaff.Name = staffDto.Name;   
            existingStaff.Age = staffDto.Age;   
            existingStaff.PhoneNumber = staffDto.PhoneNumber;   
            existingStaff.Address = staffDto.Address;   
            existingStaff.Sex = staffDto.Sex;   

            await _context.SaveChangesAsync();
            return existingStaff;
        }
    }
}