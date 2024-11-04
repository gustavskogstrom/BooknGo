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

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _context.Customers
                .Include(c => c.Bookings)
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers
                .Include(c => c.Bookings)
                .ToListAsync();

            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Guid id, CustomerDto customerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;

            _mapper.Map(customerDto, customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
