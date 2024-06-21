using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bill;
using api.Dtos.BillInfo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controlers
{
    [Route("api/billInfo")]
    [ApiController]
    public class BillInfoController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBillInfoRepository _billInfoRepo;
        private readonly IBillRepository _billRepo;
        private readonly IProductRepository _productRepo;
        public BillInfoController(ApplicationDBContext context, IBillInfoRepository billInfoRepo, IBillRepository  billRepo,  IProductRepository productRepo)
        {
            _context = context;
            _billInfoRepo = billInfoRepo;
            _billRepo =  billRepo;
            _productRepo = productRepo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var billInfo = await _billInfoRepo.GetAllAsync();
            var billInfoDto = billInfo.Select(c => c.ToBillInfoDto());
            return Ok(billInfoDto   );
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var billInfo = await _billInfoRepo.GetByIdAsync(id);
            if (billInfo == null) return NotFound();

            else return  Ok(billInfo.ToBillInfoDto());
        }
        [HttpPost("{billId}/{productId}")]
        public async Task<IActionResult> Create([FromBody] CreateBillInfoRequestDto BillInfoDto, [FromRoute] int billId, [FromRoute] int productId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _billRepo.BillExists(billId) || !await _productRepo.ProductExists(productId))
            {
                return BadRequest("Bill or Product is not exist");
            }
            var BillInfoModel = BillInfoDto.ToBillInfoFromCreateDto(billId,productId);
            await _billInfoRepo.CreateAsync(BillInfoModel);
            return CreatedAtAction(nameof(GetById), new { id = BillInfoModel.id }, BillInfoModel.ToBillInfoDto());
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,
         [FromBody] UpdateBillInfoRequestDto BillInfoDto)
         {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var billInfoModel = await _billInfoRepo.UpdateAsync(id, BillInfoDto);
            if(billInfoModel==null) 
            {return NotFound();}            
            await  _context.SaveChangesAsync();
            return Ok(billInfoModel.ToBillInfoDto());
         }
         [HttpDelete]
         [Route("delete/{id}")]
         public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var billInfoModel = await _billInfoRepo.DeleteAsync(id);

            if(billInfoModel == null)
            {
                return  NotFound();
            }
            return  NoContent();
        }
    }
}