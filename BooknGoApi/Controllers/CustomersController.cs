using Microsoft.AspNetCore.Mvc;
using BooknGoApi.Dtos;
using BooknGoApi.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Authorization;

namespace BooknGoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger, IMapper mapper)
        {
            _customerService = customerService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllcustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            if (customers == null || customers.Count == 0)
            {
                _logger.LogWarning("No customers found.");
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetcustomerById(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                _logger.LogWarning($"customer with ID {id} not found.");
                return NotFound("customer not found.");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Createcustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError("Invalid customer data.");
                return BadRequest("customer data is invalid.");
            }

            var createdcustomer = await _customerService.CreateCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetcustomerById), new { id = createdcustomer.Id }, createdcustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecustomer(Guid id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError("Invalid customer data.");
                return BadRequest("customer data is invalid.");
            }

            var updatedcustomer = await _customerService.UpdateCustomerAsync(id, customerDto);
            if (updatedcustomer == null)
            {
                return NotFound("customer not found.");
            }
            return Ok(updatedcustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(Guid id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);
            if (!deleted)
            {
                return NotFound("customer not found.");
            }
            return NoContent();
        }
    }

}