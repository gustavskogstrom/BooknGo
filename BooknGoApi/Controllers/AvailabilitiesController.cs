using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooknGoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;
        private readonly ILogger<AvailabilitiesController> _logger;
        private readonly IMapper _mapper;

        public AvailabilitiesController(IAvailabilityService availabilityService, ILogger<AvailabilitiesController> logger, IMapper mapper)
        {
            _availabilityService = availabilityService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailabilities()
        {
            var availabilities = await _availabilityService.GetAllAvailabilitiesAsync();
            if (availabilities == null || availabilities.Count == 0)
            {
                _logger.LogWarning("No availabilities found.");
                return NotFound("No availabilities found.");
            }
            return Ok(availabilities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailabilityById(Guid id)
        {
            var availability = await _availabilityService.GetAvailabilityByIdAsync(id);
            if (availability == null)
            {
                _logger.LogWarning($"Availability with ID {id} not found.");
                return NotFound("Availability not found.");
            }
            return Ok(availability);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAvailability([FromBody] AvailabilityDto availabilityDto)
        {
            if (availabilityDto == null)
            {
                _logger.LogError("Invalid availability data.");
                return BadRequest("Availability data is invalid.");
            }

            var createdAvailability = await _availabilityService.CreateAvailabilityAsync(availabilityDto);
            return CreatedAtAction(nameof(GetAvailabilityById), new { id = createdAvailability.Id }, createdAvailability);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(Guid id, [FromBody] AvailabilityDto availabilityDto)
        {
            if (availabilityDto == null)
            {
                _logger.LogError("Invalid availability data.");
                return BadRequest("Availability data is invalid.");
            }

            var updatedAvailability = await _availabilityService.UpdateAvailabilityAsync(id, availabilityDto);
            if (updatedAvailability == null)
            {
                return NotFound("Availability not found.");
            }
            return Ok(updatedAvailability);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(Guid id)
        {
            var deleted = await _availabilityService.DeleteAvailabilityAsync(id);
            if (!deleted)
            {
                return NotFound("Availability not found.");
            }
            return NoContent();
        }
    }
}