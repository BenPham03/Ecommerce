using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoiceInfo;
using api.Models;

namespace api.Mappers
{
    public static class ImportInvoiceInfoMappers
    {
        public static ImportInvoiceInfoDto ToImportInvoiceInfoDto(this ImportInvoiceInfo importInvoiceInfoModel)
        {
            return new ImportInvoiceInfoDto
            {
                id = importInvoiceInfoModel.id,
                count = importInvoiceInfoModel.count,
                SupplierID = importInvoiceInfoModel.SupplierID,
                ImportInvoiceid = importInvoiceInfoModel.ImportInvoiceid,
                Productid = importInvoiceInfoModel.Productid
            };
        }
        public static ImportInvoiceInfo ToImportInvoiceInfoFromCreateDto(this CreateImportInvoiceInfoRequestDto importInvoiceInfoDto, int SupplierID,
        int ImportInvoiceid, int Productid)
        {
            return new ImportInvoiceInfo
            {
                count = importInvoiceInfoDto.count,
                SupplierID = SupplierID,
                ImportInvoiceid = ImportInvoiceid,
                Productid = Productid
            };
        }
    }
}