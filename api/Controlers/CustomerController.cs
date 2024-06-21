using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Customer;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICustomerRepository _customerRepo;
        public CustomerController(ApplicationDBContext context, ICustomerRepository customerRepo)
        {
            _context = context;
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _customerRepo.GetAllAsync();
            var CustomerDto = customer.Select(s => s.ToCustomerDto());
            // Console.WriteLine(product);
            return Ok(CustomerDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _customerRepo.GetByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer.ToCustomerDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequestDto customerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = customerDto.ToCustomerFromCreateDto();
            await _customerRepo.CreateAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new{id  = customerModel.id}, customerModel.ToCustomerDto());
        }
        [HttpPut]
        [Route( "update/{id}" )]
        public async Task<IActionResult> Update([FromRoute] int id,
         [FromBody] UpdateCustomerRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = await _customerRepo.UpdateAsync(id, updateDto);
            if(customerModel == null)
            {
                return NotFound();
            }
            
            await _context.SaveChangesAsync();
            return Ok(customerModel.ToCustomerDto());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var customerModel = await _customerRepo.DeleteAsync(id);
            if(customerModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}