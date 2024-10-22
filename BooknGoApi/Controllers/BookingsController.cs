using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly ILogger<BookingsController> _logger;
    private readonly IMapper _mapper;

    public BookingsController(IBookingService bookingService, ILogger<BookingsController> logger, IMapper mapper)
    {
        _bookingService = bookingService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookingsAsync();
        if (bookings == null || bookings.Count == 0)
        {
            _logger.LogWarning("No bookings found.");
            return NotFound("No bookings found.");
        }
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(Guid id)
    {
        var booking = await _bookingService.GetBookingByIdAsync(id);
        if (booking == null)
        {
            _logger.LogWarning($"Booking with ID {id} not found.");
            return NotFound("Booking not found.");
        }
        return Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            _logger.LogError("Invalid booking data.");
            return BadRequest("Booking data is invalid.");
        }

        var createdBooking = await _bookingService.CreateBookingAsync(bookingDto);
        return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(Guid id, [FromBody] BookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            _logger.LogError("Invalid booking data.");
            return BadRequest("Booking data is invalid.");
        }

        var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingDto);
        if (updatedBooking == null)
        {
            return NotFound("Booking not found.");
        }
        return Ok(updatedBooking);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(Guid id)
    {
        var deleted = await _bookingService.DeleteBookingAsync(id);
        if (!deleted)
        {
            return NotFound("Booking not found.");
        }
        return NoContent();
    }
}