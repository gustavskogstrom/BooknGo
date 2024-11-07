using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            var customers = await _customerService.GetAllCustomers();
            if (customers == null || customers.Count == 0)
            {
                _logger.LogWarning("No customers found.");
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                _logger.LogWarning($"Customer with ID {id} not found.");
                return NotFound("Customer not found.");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError("Invalid customer data.");
                return BadRequest("Customer data is invalid.");
            }

            var createdCustomer = await _customerService.AddCustomer(customerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(Guid id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError("Invalid customer data.");
                return BadRequest("Customer data is invalid.");
            }

            var updatedCustomer = await _customerService.UpdateCustomer(id, customerDto);
            if (updatedCustomer == null)
            {
                _logger.LogWarning($"Customer with ID {id} not found for update.");
                return NotFound("Customer not found.");
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> Delete(Guid id)
        {
            var deletedCustomer = await _customerService.DeleteCustomer(id);
            if (deletedCustomer == null)
            {
                _logger.LogWarning($"Customer with ID {id} not found for deletion.");
                return NotFound("Customer not found.");
            }

            return Ok(deletedCustomer);
        }
    }
}
