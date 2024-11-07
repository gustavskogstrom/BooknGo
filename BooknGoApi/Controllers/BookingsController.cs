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
        public async Task<ActionResult<List<BookingDto>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            if (bookings == null || bookings.Count == 0)
            {
                _logger.LogWarning("No bookings found.");
                return NotFound("No bookings found.");
            }
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingById(Guid id)
        {
            var booking = await _bookingService.GetBookingsById(id);
            if (booking == null)
            {
                _logger.LogWarning($"Booking with ID {id} not found.");
                return NotFound("Booking not found.");
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> AddBooking([FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            var addedBooking = await _bookingService.AddBooking(bookingDto);
            return CreatedAtAction(nameof(GetBookingById), new { id = addedBooking.Id }, addedBooking);
        }

        [HttpPost("Customer/{customerId}/CreateBooking")]
        public async Task<ActionResult<BookingDto>> CreateBooking(Guid customerId, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            var createdBooking = await _bookingService.CreateBooking(customerId, bookingDto);
            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDto>> UpdateBooking(Guid id, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                _logger.LogError("Invalid booking data.");
                return BadRequest("Booking data is invalid.");
            }

            var updatedBooking = await _bookingService.UpdateBooking(id, bookingDto);
            if (updatedBooking == null)
            {
                _logger.LogWarning($"Booking with ID {id} not found for update.");
                return NotFound("Booking not found.");
            }

            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDto>> DeleteBooking(Guid id)
        {
            var deletedBooking = await _bookingService.DeleteBooking(id);
            if (deletedBooking == null)
            {
                _logger.LogWarning($"Booking with ID {id} not found for deletion.");
                return NotFound("Booking not found.");
            }

            return Ok(deletedBooking);
        }

        [HttpGet("Customer/{customerId}")]
        public async Task<ActionResult<List<BookingDto>>> GetBookingsByCustomerId(Guid customerId)
        {
            var bookings = await _bookingService.GetByCustomerId(customerId);
            if (bookings == null || bookings.Count == 0)
            {
                _logger.LogWarning($"No bookings found for customer ID {customerId}.");
                return NotFound("No bookings found for this customer.");
            }

            return Ok(bookings);
        }
    }
}
