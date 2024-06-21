using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Staff;
using api.Models;

namespace api.Interfaces
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllAsync();
        Task<Staff?> GetByIdAsync(int id);
        Task<Staff> CreateAsync(Staff staffModel);
        Task<Staff?> UpdateAsync(int id, UpdateStaffRequestDto staffDto);
        Task<Staff?> DeleteAsync(int id);
        Task<bool> StaffExist(int staffid);
    }
}