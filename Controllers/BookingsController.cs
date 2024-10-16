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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDTO>> GetAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            var bookingDTOs = _mapper.Map<IEnumerable<BookingDTO>>(bookings);
            return Ok(bookingDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDTO> GetBookingById(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDTO = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDTO);
        }

        [HttpPost]
        public ActionResult<BookingDTO> AddBooking(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            var newBooking = _bookingService.AddBooking(booking);
            var newBookingDTO = _mapper.Map<BookingDTO>(newBooking);
            return CreatedAtAction(nameof(GetBookingById), new { id = newBookingDTO.BookingId }, newBookingDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, BookingDTO updatedBookingDTO)
        {
            var updatedBooking = _mapper.Map<Booking>(updatedBookingDTO);
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
