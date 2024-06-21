using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Supplier;
using api.Models;

namespace api.Mappers
{
    public static class SupplierMappers
    {
        public static SupplierDto ToSupplierDto(this Supplier supplierModel)
        {
            return new SupplierDto
            {
                id = supplierModel.id,
                name = supplierModel.name,
                Address = supplierModel.Address,
                ImportInvoiceInfos = supplierModel.ImportInvoiceInfos.Select(c => c.ToImportInvoiceInfoDto()).ToList()
            };
        }
        public static Supplier ToSupplierFromCreateDto(this CreateSupplierRequestDto supplierDto)
        {
            return new Supplier
            {
                name = supplierDto.name,
                Address = supplierDto.Address
            };
        }
    }
}