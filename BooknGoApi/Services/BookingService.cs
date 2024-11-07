using AutoMapper;
using BooknGoApi.Data;
using BooknGoApi.Data.Models;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooknGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly BooknGoDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(BooknGoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingsById(Guid id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking == null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> CreateBooking(Guid customerId, BookingDto bookingDto)
        {
            if (bookingDto == null)
                throw new ArgumentNullException(nameof(bookingDto));

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.CustomerId = customerId;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> AddBooking(BookingDto bookingDto)
        {
            if (bookingDto == null)
                throw new ArgumentNullException(nameof(bookingDto));

            var booking = _mapper.Map<Booking>(bookingDto);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> UpdateBooking(Guid id, BookingDto bookingDto)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return null;

            _mapper.Map(bookingDto, booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> DeleteBooking(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return null;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<List<BookingDto>> GetByCustomerId(Guid customerId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();

            return _mapper.Map<List<BookingDto>>(bookings);
        }
    }
}
