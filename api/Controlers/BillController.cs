using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bill;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        
        private readonly ApplicationDBContext _context;
        private readonly IBillRepository _billRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IStaffRepository _staffRepo;
        public BillController(ApplicationDBContext context,  IBillRepository billRepo, ICustomerRepository customerRepo, IStaffRepository staffRepo)
        {
            _context = context;
            _billRepo = billRepo;
            _customerRepo = customerRepo;
            _staffRepo = staffRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var bill = await _billRepo.GetAllAsync();
            var billDto = bill.Select(c => c.ToBillDto());  
            return Ok(billDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var bill = await _billRepo.GetByIdAsync(id);
            if (bill == null) return NotFound();
            else return  Ok(bill.ToBillDto());
        }
        [HttpPost("{customerId:int}/{staffId:int}")]
        public async Task<IActionResult> Create([FromBody] CreateBillRequestDto BillDto, [FromRoute] int customerId, [FromRoute]int staffId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _customerRepo.CustomerExists(customerId) || !await _staffRepo.StaffExist(staffId))
            {
                return BadRequest("Customer or Staff is not exist!");
            }
            var BillModel =  BillDto.ToBillFromCreateDto(customerId,staffId);
            await _billRepo.CreateAsync(BillModel);
            return CreatedAtAction(nameof(GetById), new { id = BillModel.id }, BillModel.ToBillDto());
        }
        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,
         [FromBody] UpdateBillRequestDto BillDto)
         {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var billModel = await _billRepo.UpdateAsync(id, BillDto);
            if(billModel==null) 
            {return NotFound();}            
            
            await  _context.SaveChangesAsync();
            return Ok(billModel.ToBillDto());
         }
         [HttpDelete]
         [Route("delete/{id:int}")]
         public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var billModel = await _billRepo.DeleteAsync(id);
            if(billModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}