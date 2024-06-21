using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BillInfo;
using api.Models;

namespace api.Mappers
{
    public static class BillInfoMappers
    {
        public static BillInfoDto ToBillInfoDto(this BillInfo billModel)
        {
            return new BillInfoDto
            {
                id = billModel.id,
                count = billModel.count,
                Billid = billModel.Billid,
                Productid = billModel.Productid
            };
        }
        public static BillInfo ToBillInfoFromCreateDto(this CreateBillInfoRequestDto billInfoDto ,int billId, int productId)
        {
            return new BillInfo
            {
                count = billInfoDto.count,
                Billid = billId,
                Productid = productId
            };
        }
    }
}