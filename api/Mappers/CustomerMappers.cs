using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Models;

namespace api.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                id = customerModel.id,
                Name = customerModel.Name,
                Age = customerModel.Age,
                PhoneNumber = customerModel.PhoneNumber,
                Address = customerModel.Address,
                Sex = customerModel.Sex,
                Bills = customerModel.Bills.Select(c => c.ToBillDto()).ToList()
            };
        }
         public static Customer ToCustomerFromCreateDto(this CreateCustomerRequestDto customerDto)
         {
             return new Customer 
             {
                Name = customerDto.Name,
                Age = customerDto.Age,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
                Sex = customerDto.Sex
             };
         }  
    }
}