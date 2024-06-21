using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int id);
        Task<Users> CreateAsync(Users usersModel);
        Task<Users?> UpdateAsync(int id, UpdateUserRequestDto usersDto);
        Task<Users?> DeleteAsync(int id);
        Task<Users?> LoginAsync(LoginDTO loginDTO);
        Task<bool> UserExists(int id);
    }
}