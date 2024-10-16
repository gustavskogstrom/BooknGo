using BooknGo.Data.Models;
using BooknGo.Data;
using BooknGo.Interfaces;

namespace BooknGo.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookNGoDbContext _context;

        public BookingService(BookNGoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.BookingId == id);
        }

        public Booking AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public bool UpdateBooking(int id, Booking updatedBooking)
        {
            var booking = GetBookingById(id);
            if (booking == null)
            {
                return false;
            }

            booking.BookingDate = updatedBooking.BookingDate;
            booking.ServiceDate = updatedBooking.ServiceDate;
            booking.CustomerId = updatedBooking.CustomerId;
            booking.ServiceId = updatedBooking.ServiceId;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteBooking(int id)
        {
            var booking = GetBookingById(id);
            if (booking == null)
            {
                return false;
            }
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return true;
        }
    }
}
