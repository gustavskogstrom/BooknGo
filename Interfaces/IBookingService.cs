using BooknGo.Data.Models;

namespace BooknGo.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        Booking AddBooking(Booking booking);
        bool UpdateBooking(int id, Booking updatedBooking);
        bool DeleteBooking(int id);
    }

}
