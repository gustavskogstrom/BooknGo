using BooknGoApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooknGoApi.Interface
{
    public interface IBookingService
    {
        Task<BookingDto> GetBookingByIdAsync(Guid id);
        Task<List<BookingDto>> GetAllBookingsAsync();
        Task AddBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(Guid id, BookingDto bookingDto);
        Task DeleteBookingAsync(Guid id);
        Task<List<BookingDto>> GetByCustomerId(Guid id);
        Task<BookingDto> CreateBooking(Guid customerId, BookingDto bookingDto);
    }
}
