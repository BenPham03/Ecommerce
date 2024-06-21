using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Staff;
using Microsoft.AspNetCore.Http.HttpResults;
using api.Models;
using api.Dtos.Product;
using api.Dtos.Supplier;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controlers
{
    [Route("api/staff")]
    [ApiController]

    public class StaffController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private  readonly IStaffRepository _StaffRepo;
        public StaffController(ApplicationDBContext context, IStaffRepository staffRepo)
        {
            _context = context;
            _StaffRepo = staffRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var  staffs = await _StaffRepo.GetAllAsync();
            var staffDto = staffs.Select(s=> s.ToStaffDto());
            return Ok(staffDto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var  staff= await _StaffRepo.GetByIdAsync(id);
            if(staff == null)
            {
                return NotFound();
            }
            return Ok(staff.ToStaffDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStaffRequestDto  staffDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var staffModel =  staffDto.ToStaffFromCreateDto();
            await _StaffRepo.CreateAsync(staffModel);
            return CreatedAtAction(nameof(GetById), new { id =staffModel.id}, staffModel.ToStaffDto());
        }
        [HttpPut]
        [Route( "update/{id}" )]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateStaffRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var staffModel = await _StaffRepo.UpdateAsync(id, updateDto);
            if(staffModel == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return Ok(staffModel.ToStaffDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var staffModel = await _StaffRepo.DeleteAsync(id);
            if(staffModel == null)
            {
                return  NotFound(); 
            }
            return  NoContent();
        }
    }
}