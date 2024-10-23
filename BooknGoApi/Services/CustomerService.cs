using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly List<CustomerDto> _customers;

        public CustomerService(IMapper mapper)
        {
            _mapper = mapper;
            _customers = new List<CustomerDto>(); // Mocked in-memory data store
        }

        public async Task<IList<CustomerDto>> GetAllCustomersAsync()
        {
            return await Task.FromResult(_customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = _customers.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(customer);
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
        {
            customerDto.Id = Guid.NewGuid();
            _customers.Add(customerDto);
            return await Task.FromResult(customerDto);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerDto customerDto)
        {
            var existingCustomer = _customers.FirstOrDefault(u => u.Id == id);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customerDto.Name;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.PasswordHash = customerDto.PasswordHash;
            existingCustomer.Role = customerDto.Role;

            return await Task.FromResult(existingCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(Guid id)
        {
            var customer = _customers.FirstOrDefault(u => u.Id == id);
            if (customer == null)
            {
                return await Task.FromResult(false);
            }

            _customers.Remove(customer);
            return await Task.FromResult(true);
        }
    }
}
