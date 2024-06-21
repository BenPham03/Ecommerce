using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Customer;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateAsync(Customer customerModel)
        {
            await _context.Customer.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<bool> CustomerExists(int customerId)
        {
            return await _context.Customer.AnyAsync(s => s.id == customerId);
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var customerModel = await _context.Customer.FirstOrDefaultAsync(x => x.id == id);
            if(customerModel == null)
            {
                return null;
            }
            _context.Customer.Remove(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customer.Include(c => c.Bills).Include(c => c.Users).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customer.Include(c => c.Bills).Include(c=> c.Users).FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Customer?> UpdateAsync(int id, UpdateCustomerRequestDto customerDto)
        {
            var existingCustomer = await _context.Customer.FirstOrDefaultAsync(x => x.id == id);
            if(existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customerDto.Name;
            existingCustomer.Age = customerDto.Age;
            existingCustomer.PhoneNumber = customerDto.PhoneNumber;
            existingCustomer.Address = customerDto.Address;
            existingCustomer.Sex = customerDto.Sex;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }
    }
}