using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> CommentExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment?> CreateAsync(Comment commentModel)
        {
            await _context.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comnentModel = await _context.Comment.FirstOrDefaultAsync(s => s.id == id);
            if (comnentModel == null)
            {
                return null;
            }
            _context.Comment.Remove(comnentModel);
            await _context.SaveChangesAsync();
            return comnentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto commentDto)
        {
            var existComment = await _context.Comment.FirstOrDefaultAsync(s => s.id == id);
            if(existComment == null)
            {
                return null;
            }
            existComment.Content = commentDto.Content;
            existComment.Title = commentDto.Title;
            await _context.SaveChangesAsync();
            return existComment;
            
        }
    }
}