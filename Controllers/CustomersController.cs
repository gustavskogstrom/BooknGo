using AutoMapper;
using BooknGo.Data.Models;
using BooknGo.DTOs;
using BooknGo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooknGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        public ActionResult<CustomerDTO> AddCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var newCustomer = _customerService.AddCustomer(customer);
            var newCustomerDTO = _mapper.Map<CustomerDTO>(newCustomer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomerDTO.CustomerId }, newCustomerDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerDTO updatedCustomerDTO)
        {
            var updatedCustomer = _mapper.Map<Customer>(updatedCustomerDTO);
            if (!_customerService.UpdateCustomer(id, updatedCustomer))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_customerService.DeleteCustomer(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
