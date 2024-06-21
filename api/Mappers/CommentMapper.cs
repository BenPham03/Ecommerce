using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                id = commentModel.id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreateOn = commentModel.CreateOn,
                productId = commentModel.productId,
                userID = commentModel.userID
            };
        }
         public static Comment ToCommentFromCreate(this CreateCommentDto commentDto,int userId, int  productId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                productId = productId,
                userID = userId
            };
        }
    }
}