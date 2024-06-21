using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Supplier;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ISupplierRepository _supplierRepo;
        public SupplierController(ApplicationDBContext context, ISupplierRepository supplierRepo)
        {
            _context = context;
            _supplierRepo = supplierRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var  supplier = await _supplierRepo.GetAllAsync();
            var supplierDto = supplier.Select(s=> s.ToSupplierDto());
            return Ok(supplierDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var  supplier= await _supplierRepo.GetByIdAsync(id);
            if(supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier.ToSupplierDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequestDto  supplierDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierModel =  supplierDto.ToSupplierFromCreateDto();
            await _supplierRepo.CreateAsync(supplierModel);
            return CreatedAtAction(nameof(GetById), new { id =supplierModel.id}, supplierModel.ToSupplierDto());
        }
        [HttpPut]
        [Route( "update/{id}" )]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateSupplierRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierModel = await _supplierRepo.UpdateAsync(id, updateDto);
            if(supplierModel == null)
            {
                return NotFound();
            }
            return Ok(supplierModel.ToSupplierDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var supplierModel = await _supplierRepo.DeleteAsync(id);
            if(supplierModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}