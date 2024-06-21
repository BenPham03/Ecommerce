using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ImportInvoiceInfo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/importInvoiceInfo")]
    [ApiController]
    public class ImportInvoiceInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IImportInvoiceInfoRepository _importInvoiceInfoRepo;
        private readonly IImportInvoiceRepository _importInvoiceRepo;
        private readonly ISupplierRepository _supplierRepo;
        private readonly IProductRepository _productRepo;
        public ImportInvoiceInfoController(ApplicationDBContext context, IImportInvoiceInfoRepository importInvoiceInfoRepo, ISupplierRepository supplierRepo,
        IProductRepository productRepo, IImportInvoiceRepository importInvoiceRepo)
        {
            _importInvoiceInfoRepo = importInvoiceInfoRepo;
            _context = context;
            _productRepo = productRepo;
            _importInvoiceRepo = importInvoiceRepo;
            _supplierRepo = supplierRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var importInvoiceInfo = await _importInvoiceInfoRepo.GetAllAsync();
            var imporeInvoiceInfoDto = importInvoiceInfo.Select(c => c.ToImportInvoiceInfoDto());
            return Ok(imporeInvoiceInfoDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var importInvoice = await _importInvoiceInfoRepo.GetByIdAsync(id);
            if (importInvoice == null) return NotFound();
            else return Ok(importInvoice.ToImportInvoiceInfoDto());
        }
        [HttpPost("{supplierId}/{importInvoiceId}/{productId}")]
        public async Task<IActionResult> Create([FromBody] CreateImportInvoiceInfoRequestDto imporeInvoiceInfoDto,
         [FromRoute] int supplierId, [FromRoute] int importInvoiceId, [FromRoute] int productId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _importInvoiceRepo.ImportInvoiceExist(importInvoiceId)
            || !await _supplierRepo.SupplierExist(supplierId)
             || !await _productRepo.ProductExists(productId))
            {
                return BadRequest("Invalid ImportInvoiceId, SupplierId or ProductId");
            }
            var importInvoiceInfoModel = imporeInvoiceInfoDto.ToImportInvoiceInfoFromCreateDto(supplierId,importInvoiceId,productId);
            await _importInvoiceInfoRepo.CreateAsync(importInvoiceInfoModel);
            return CreatedAtAction(nameof(GetById), new {id = importInvoiceInfoModel.id}, importInvoiceInfoModel.ToImportInvoiceInfoDto());
        }   
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateImportInvoiceInfoRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var importInvoiceInfoModel = await _importInvoiceInfoRepo.UpdateAsync(id, updateDto);
            if (importInvoiceInfoModel == null)
            {
                return NotFound();
            }



            await _context.SaveChangesAsync();
            return Ok(importInvoiceInfoModel.ToImportInvoiceInfoDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var importInvoiceInfoModel = await _importInvoiceInfoRepo.DeleteAsync(id);
            if (importInvoiceInfoModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}