using AutoMapper;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

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
}
