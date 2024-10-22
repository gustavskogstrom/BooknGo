using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IBookingService
    {
        Task<IList<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(Guid id);
        Task<BookingDto> CreateBookingAsync(BookingDto bookingDto);
        Task<BookingDto> UpdateBookingAsync(Guid id, BookingDto bookingDto);
        Task<bool> DeleteBookingAsync(Guid id);
    }
}
