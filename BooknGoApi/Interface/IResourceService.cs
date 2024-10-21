using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IResourceService
    {
        Task<IList<ResourceDto>> GetAllResourcesAsync();
    }
}
