using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateAsync(Users usersModel)
        {
            await _context.Users.AddAsync(usersModel);
            await _context.SaveChangesAsync();
            return usersModel;
        }

        public async Task<Users?> DeleteAsync(int id)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (usersModel == null)
            {
                return null;
            }
            _context.Users.Remove(usersModel);
            await _context.SaveChangesAsync();
            return usersModel;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Users.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(c=> c.Comments).FirstOrDefaultAsync(c => c.ID ==id);
        }

        public async Task<Users?> LoginAsync(LoginDTO loginDTO)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email && x.PassWord == loginDTO.PassWord && x.UserName == loginDTO.UserName);
            if(existingUser == null)
            {
                return null;
            }
            return existingUser;
        }

        public async Task<Users?> UpdateAsync(int id, UpdateUserRequestDto usersDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Email = usersDto.Email;
            existingUser.PassWord = usersDto.PassWord;
            existingUser.Fund = usersDto.Fund;
            existingUser.Type = usersDto.Type;
            existingUser.UserName = usersDto.UserName;
            existingUser.CustomerId = usersDto.CustomerId;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public  async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(s=> s.ID == id);
        }
    }
}