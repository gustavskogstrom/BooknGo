using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface ICustomerService
    {
        Task<IList<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(Guid id);
        Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}
