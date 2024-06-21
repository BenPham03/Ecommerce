using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this Users userModel)
        {
            return new UserDto
            {
                ID = userModel.ID,
                Email = userModel.Email,
                PassWord = userModel.PassWord,
                Fund = userModel.Fund,
                Type = userModel.Type,
                UserName = userModel.UserName,
                comments = userModel.Comments.Select(i => i.ToCommentDto()).ToList()

            };
        }
        public static Users ToUserFromCreateDto(this CreateUserRequestDto userRequestDto)
        {
            return new Users
            {
                Email = userRequestDto.Email,
                PassWord = userRequestDto.PassWord,
                Fund = userRequestDto.Fund,
                Type = userRequestDto.Type,
                UserName = userRequestDto.UserName

            };
        }
    }
}