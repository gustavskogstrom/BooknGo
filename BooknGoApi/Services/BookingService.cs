using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly List<BookingDto> _bookings;

        public BookingService(IMapper mapper)
        {
            _mapper = mapper;
            _bookings = new List<BookingDto>(); // Mocked in-memory data store
        }

        public async Task<IList<BookingDto>> GetAllBookingsAsync()
        {
            return await Task.FromResult(_bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(Guid id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(booking);
        }

        public async Task<BookingDto> CreateBookingAsync(BookingDto bookingDto)
        {
            bookingDto.Id = Guid.NewGuid();
            _bookings.Add(bookingDto);
            return await Task.FromResult(bookingDto);
        }

        public async Task<BookingDto> UpdateBookingAsync(Guid id, BookingDto bookingDto)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id == id);
            if (existingBooking == null)
            {
                return null;
            }

            existingBooking.BookingDate = bookingDto.BookingDate;
            existingBooking.Status = bookingDto.Status;
            existingBooking.UserId = bookingDto.UserId;
            existingBooking.ResourceId = bookingDto.ResourceId;

            return await Task.FromResult(existingBooking);
        }

        public async Task<bool> DeleteBookingAsync(Guid id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                return await Task.FromResult(false);
            }

            _bookings.Remove(booking);
            return await Task.FromResult(true);
        }
    }
}
