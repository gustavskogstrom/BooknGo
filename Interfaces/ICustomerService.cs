using BooknGo.Data.Models;

namespace BooknGo.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer AddCustomer(Customer customer);
        bool UpdateCustomer(int id, Customer updatedCustomer);
        bool DeleteCustomer(int id);
    }
}
