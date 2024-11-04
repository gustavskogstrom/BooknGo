using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLitePCL;
using System;
using System.Threading.Tasks;

namespace BooknGoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(IBookingService bookingService, ILogger<BookingsController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                _logger.LogWarning($"Booking with ID {id} not found.");
                return NotFound("Booking not found.");
            }
            return Ok(booking);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            await _bookingService.UpdateBookingAsync(id, bookingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetByCustomerId(Guid id)
        {
            var booking = await _bookingService.GetByCustomerId(id);
            if (booking == null)
            {
                _logger.LogWarning($"Booking with ID {id} not found.");
                return NotFound("Booking not found.");
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            await _bookingService.AddBookingAsync(bookingDto);
            return CreatedAtAction(nameof(GetById), new { id = bookingDto.Id }, bookingDto);
        }

        [HttpPost("Customer/{customerId}/CreateBooking")]
        public async Task<IActionResult> CreateBooking(Guid customerId, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            try
            {
                var createdBooking = await _bookingService.CreateBooking(customerId, bookingDto);
                return CreatedAtAction(nameof(GetById), new { id = createdBooking.Id }, createdBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create booking: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}