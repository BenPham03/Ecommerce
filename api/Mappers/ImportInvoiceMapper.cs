using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ImportInvoice;
using api.Models;

namespace api.Mappers
{
    public static class ImportInvoiceMapper
    {
        public static ImportInvoiceDto ToImportInvoiceDto(this ImportInvoice importInvoiceModel)
        {
            return new ImportInvoiceDto
            {
                id = importInvoiceModel.id,
                Date = importInvoiceModel.Date,
                status = importInvoiceModel.status,
                Staffid = importInvoiceModel.Staffid,
                ImportInvoiceInfos = importInvoiceModel.ImportInvoiceInfos.Select(c => c.ToImportInvoiceInfoDto()).ToList()
            };
        }
        public static ImportInvoice ToImportInvoiceFromCreateDto(this CreateImportInvoiceRequestDto importInvoiceDto, int staffId)
        {
            return new ImportInvoice
            {
                status = importInvoiceDto.status,
                Staffid = staffId,
            };
        }
    }
}