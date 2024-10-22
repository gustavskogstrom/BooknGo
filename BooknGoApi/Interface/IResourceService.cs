using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IResourceService
    {
        Task<IList<ResourceDto>> GetAllResourcesAsync();
        Task<ResourceDto> GetResourceByIdAsync(Guid id);
        Task<ResourceDto> CreateResourceAsync(ResourceDto resourceDto);
        Task<ResourceDto> UpdateResourceAsync(Guid id, ResourceDto resourceDto);
        Task<bool> DeleteResourceAsync(Guid id);
    }
}
