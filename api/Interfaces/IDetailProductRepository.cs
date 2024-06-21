using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DetailProduct;
using api.Models;

namespace api.Interfaces
{
    public interface IDetailProductRepository
    {
        Task<List<DetailProduct>> GetAllAsync();
        Task<DetailProduct?> GetByIdAsync(int id);
        Task<DetailProduct> CreateAsync(DetailProduct model);
        Task<DetailProduct?> UpdateAsync(int id, UpdateDetailProductRequest model);
        Task<DetailProduct?> DeleteAsync(int id);
        Task<bool> DetailProductExist(int id);


    }
}