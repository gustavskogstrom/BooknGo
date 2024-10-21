using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IBookingService
    {
        Task<IList<BookingDto>> GetAllBookingsAsync();
    }
}
