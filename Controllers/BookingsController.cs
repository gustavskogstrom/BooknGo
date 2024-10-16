using BooknGo.Data.Models;
using BooknGo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooknGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAllBookings()
        {
            return Ok(_bookingService.GetAllBookings());
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<Booking> AddBooking(Booking booking)
        {
            var newBooking = _bookingService.AddBooking(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.BookingId }, newBooking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, Booking updatedBooking)
        {
            if (!_bookingService.UpdateBooking(id, updatedBooking))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            if (!_bookingService.DeleteBooking(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
