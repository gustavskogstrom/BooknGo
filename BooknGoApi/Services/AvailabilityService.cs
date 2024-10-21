using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IMapper _mapper;

        public AvailabilityService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            // Implementation for retrieving all availabilities
            var availabilities = new List<AvailabilityDto>();
            return await Task.FromResult(availabilities);
        }
    }
}
