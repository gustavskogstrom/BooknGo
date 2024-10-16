using BooknGo.Data;
using BooknGo.Data.Models;
using BooknGo.Interfaces;

namespace BooknGo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BookNGoDbContext _context;

        public CustomerService(BookNGoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public bool UpdateCustomer(int id, Customer updatedCustomer)
        {
            var customer = GetCustomerById(id);
            if (customer == null)
            {
                return false;
            }

            customer.FullName = updatedCustomer.FullName;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            if (customer == null)
            {
                return false;
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
