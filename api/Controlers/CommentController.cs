using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controlers
{
    [Route("api/controller")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly  IProductRepository _productRepo;
        private readonly IUserRepository _userRepo;
        public CommentController(ICommentRepository commentRepo, IProductRepository productRepo, IUserRepository userRepo)
        {
            _commentRepo = commentRepo;
            _productRepo = productRepo;
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetAllAsync();
            var commentDto = comment.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);  
        }
        [HttpPost("{userId}/{productId}")]
        public async Task<IActionResult> Create([FromRoute] int userId, [FromRoute] int productId, [FromBody] CreateCommentDto commentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _productRepo.ProductExists(productId) || !await _userRepo.UserExists(userId))
            {
                return BadRequest("Product or user is not Exist");
            }
            var commentModel =  commentDto.ToCommentFromCreate(userId,productId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new{ id  = commentModel}, commentModel.ToCommentDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto commentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                

            var comment = await _commentRepo.UpdateAsync(id, commentDto);
            if(comment == null)
            {
                return NotFound("Comment not found");
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.DeleteAsync(id);
            if(comment == null)
            {
                return NotFound("Comment not exist");
            }
            return Ok(comment);
        }
    }
}