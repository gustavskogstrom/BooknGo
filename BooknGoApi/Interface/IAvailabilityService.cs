using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IAvailabilityService
    {
        Task<IList<AvailabilityDto>> GetAllAvailabilitiesAsync();
        Task<AvailabilityDto> GetAvailabilityByIdAsync(Guid id);
        Task<AvailabilityDto> CreateAvailabilityAsync(AvailabilityDto availabilityDto);
        Task<AvailabilityDto> UpdateAvailabilityAsync(Guid id, AvailabilityDto availabilityDto);
        Task<bool> DeleteAvailabilityAsync(Guid id);
    }
}