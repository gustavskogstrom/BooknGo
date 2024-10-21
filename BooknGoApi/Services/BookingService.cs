using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<BookingDto>> GetAllBookingsAsync()
        {
            // Implementation for retrieving all bookings
            var bookings = new List<BookingDto>();
            return await Task.FromResult(bookings);
        }
    }
}
