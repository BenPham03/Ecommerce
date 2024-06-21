using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bill;
using api.Models;

namespace api.Mappers
{
    public static class BillMapper
    {
        public static BillDto ToBillDto(this Bill billModel)
        {
            return new BillDto
            {
                id = billModel.id,
                Date = billModel.Date,
                TotalPrice = billModel.TotalPrice,
                Discount = billModel.Discount,
                staffid = billModel.staffid,
                customerId = billModel.customerId,
                BillInfos = billModel.BillInfos.Select(x => x.ToBillInfoDto()).ToList()
            };
        }
        public static Bill ToBillFromCreateDto(this CreateBillRequestDto billDto,int customerId, int staffId)
        {

            return new Bill
            {
                TotalPrice = billDto.TotalPrice,
                Discount = billDto.Discount,
                staffid = staffId,
                customerId = customerId
            };
        }
        
    }
}