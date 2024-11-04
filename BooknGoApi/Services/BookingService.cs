using AutoMapper;
using BooknGoApi.Data;
using BooknGoApi.Data.Models;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<BookingDto> GetBookingByIdAsync(Guid id)
        {
            var booking = await _context.Bookings
                //.Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Id == id);

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<List<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings
                //.Include(b => b.Customer)
                .ToListAsync();

            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task AddBookingAsync(BookingDto bookingDto)
        {
                var booking = _mapper.Map<Booking>(bookingDto);
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
        }


        public async Task UpdateBookingAsync(Guid id, BookingDto bookingDto)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return;

            _mapper.Map(bookingDto, booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookingDto>> GetByCustomerId(Guid id)
        {
            var booking = await _context.Bookings
                .Where(b => b.CustomerId == id)
                .ToListAsync();
            return _mapper.Map<List<BookingDto>>(booking);
        }

        public async Task<BookingDto> CreateBooking(Guid customerId, BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);

            booking.CustomerId = customerId;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }
    }
}
