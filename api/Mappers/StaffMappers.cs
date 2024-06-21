using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Staff;
using api.Models;

namespace api.Mappers
{
    public static class StaffMappers
    {
        public static StaffDto ToStaffDto(this Staff staffModel)
        {
            return new StaffDto
            {
                id = staffModel.id,
                Name = staffModel.Name,
                Age = staffModel.Age,
                PhoneNumber = staffModel.PhoneNumber,
                Address = staffModel.Address,
                Sex = staffModel.Sex,
                Bills = staffModel.Bills.Select(c => c.ToBillDto()).ToList(),  
                ImportInvoices = staffModel.ImportInvoices.Select(c=> c.ToImportInvoiceDto()).ToList(),
            };
        }
        public static Staff ToStaffFromCreateDto(this CreateStaffRequestDto staffDto)
        {
            return new Staff
            {
                Name = staffDto.Name,
                Age = staffDto.Age,
                PhoneNumber = staffDto.PhoneNumber,
                Address = staffDto.Address,
                Sex = staffDto.Sex
            };
        }
    }
}