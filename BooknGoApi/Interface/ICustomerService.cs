using BooknGoApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(Guid id);
        Task<CustomerDto> AddCustomer(CustomerDto customerDto);
        Task<CustomerDto> UpdateCustomer(Guid id, CustomerDto customerDto);
        Task<CustomerDto> DeleteCustomer(Guid id);
    }
}
