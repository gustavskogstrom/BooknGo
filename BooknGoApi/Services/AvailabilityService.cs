using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IMapper _mapper;
        private readonly List<AvailabilityDto> _availabilities;

        public AvailabilityService(IMapper mapper)
        {
            _mapper = mapper;
            _availabilities = new List<AvailabilityDto>(); // Mocked in-memory data store
        }

        public async Task<IList<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            return await Task.FromResult(_availabilities);
        }

        public async Task<AvailabilityDto> GetAvailabilityByIdAsync(Guid id)
        {
            var availability = _availabilities.FirstOrDefault(a => a.Id == id);
            return await Task.FromResult(availability);
        }

        public async Task<AvailabilityDto> CreateAvailabilityAsync(AvailabilityDto availabilityDto)
        {
            availabilityDto.Id = Guid.NewGuid();
            _availabilities.Add(availabilityDto);
            return await Task.FromResult(availabilityDto);
        }

        public async Task<AvailabilityDto> UpdateAvailabilityAsync(Guid id, AvailabilityDto availabilityDto)
        {
            var existingAvailability = _availabilities.FirstOrDefault(a => a.Id == id);
            if (existingAvailability == null)
            {
                return null;
            }

            existingAvailability.StartTime = availabilityDto.StartTime;
            existingAvailability.EndTime = availabilityDto.EndTime;
            existingAvailability.IsAvailable = availabilityDto.IsAvailable;

            return await Task.FromResult(existingAvailability);
        }

        public async Task<bool> DeleteAvailabilityAsync(Guid id)
        {
            var availability = _availabilities.FirstOrDefault(a => a.Id == id);
            if (availability == null)
            {
                return await Task.FromResult(false);
            }

            _availabilities.Remove(availability);
            return await Task.FromResult(true);
        }
    }
}