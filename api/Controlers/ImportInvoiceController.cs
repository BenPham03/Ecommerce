using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ImportInvoice;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/importInvoice")]
    [ApiController]
    public class ImportInvoiceController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IImportInvoiceRepository _importInvoiceRepo;
        private readonly IStaffRepository _staffRepo;
        public ImportInvoiceController(ApplicationDBContext context, IImportInvoiceRepository importInvoiceRepo, IStaffRepository staffRepo)
        {
            _importInvoiceRepo = importInvoiceRepo;
            _context = context;
            _staffRepo = staffRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var importInvoice = await _importInvoiceRepo.GetAllAsync();
            var imporeInvoiceDto = importInvoice.Select(c => c.ToImportInvoiceDto());
            return Ok(imporeInvoiceDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var importInvoice = await _importInvoiceRepo.GetByIdAsync(id);
            if (importInvoice == null) return NotFound();
            else return  Ok(importInvoice.ToImportInvoiceDto());
        }
        [HttpPost("{staffId}")]
        public async Task<IActionResult> Create([FromBody] CreateImportInvoiceRequestDto imporeInvoiceDto, [FromRoute] int staffId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _staffRepo.StaffExist(staffId))
            {
                return BadRequest("Staff is not exist");
            }
            var importInvoiceModel = imporeInvoiceDto.ToImportInvoiceFromCreateDto(staffId);
            await _importInvoiceRepo.CreateAsync(importInvoiceModel);
            return CreatedAtAction(nameof(GetById), new { id = importInvoiceModel.id }, importInvoiceModel.ToImportInvoiceDto());
        }
        [HttpPut]
        [Route( "update/{id}" )]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateImportInvoiceRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var importInvoiceModel = await _importInvoiceRepo.UpdateAsync(id, updateDto);
            if(importInvoiceModel == null)
            {
                return NotFound();
            }
            
            await _context.SaveChangesAsync();
            return Ok(importInvoiceModel.ToImportInvoiceDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var importInvoiceModel = await _importInvoiceRepo.DeleteAsync(id);

            if(importInvoiceModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}