using BooknGoApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Interface
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(Guid id);
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task AddCustomerAsync(CustomerDto customerDto);
        Task UpdateCustomerAsync(Guid id, CustomerDto customerDto);
        Task DeleteCustomerAsync(Guid id);
    }
}
