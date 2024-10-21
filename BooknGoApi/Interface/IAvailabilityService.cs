using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IAvailabilityService
    {
        Task<IList<AvailabilityDto>> GetAllAvailabilitiesAsync();
    }
}
