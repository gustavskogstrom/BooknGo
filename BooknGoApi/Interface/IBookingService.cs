using BooknGoApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Interface
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllBookings();
        Task<BookingDto> GetBookingsById(Guid id);
        Task<BookingDto> CreateBooking(Guid customerId, BookingDto bookingDto);
        Task<BookingDto> AddBooking(BookingDto bookingDto);
        Task<BookingDto> UpdateBooking(Guid id, BookingDto bookingDto);
        Task<BookingDto> DeleteBooking(Guid id);
        Task<List<BookingDto>> GetByCustomerId(Guid id);
    }
}
