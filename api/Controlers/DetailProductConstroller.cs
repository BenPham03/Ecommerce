using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Dtos.DetailProduct;
using Microsoft.AspNetCore.Mvc;

namespace api.Controlers
{
    [Route("api/DetailProduct")]
    [ApiController]
    public class DetailProductConstroller : ControllerBase
    {
        private readonly  ApplicationDBContext _context;
        private readonly IDetailProductRepository _detailProductRepo;
        public DetailProductConstroller(ApplicationDBContext context, IDetailProductRepository detailProductRepo)
        {
            _context = context;
            _detailProductRepo =  detailProductRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detail = await  _detailProductRepo.GetAllAsync();
            var DetailDto = detail.Select(s=> s.ToDetailProduct());
            return Ok(DetailDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var detailProduct = await _detailProductRepo.GetByIdAsync(id);
            if(detailProduct == null)
            {
                return NotFound();
            }
            return Ok(detailProduct.ToDetailProduct());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateDetailProductDto createDetail) 
        {
            var detailProductModel = createDetail.ToDetailProductFromCreateDto();
            await _detailProductRepo.CreateAsync(detailProductModel);
            return CreatedAtAction(nameof(GetById), new{id  = detailProductModel.id}, detailProductModel.ToDetailProduct());
        }
    }
}