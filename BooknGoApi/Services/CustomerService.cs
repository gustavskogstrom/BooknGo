using AutoMapper;
using BooknGoApi.Data;
using BooknGoApi.Data.Models;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BooknGoDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(BooknGoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            var customer = await _context.Customers
                .Include(c => c.Bookings) // Include related bookings
                .FirstOrDefaultAsync(c => c.Id == id);

            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var customers = await _context.Customers
                .Include(c => c.Bookings) // Include related bookings for all customers
                .ToListAsync();

            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCustomer(Guid id, CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;

            _mapper.Map(customerDto, customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
