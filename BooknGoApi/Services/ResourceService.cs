using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IMapper _mapper;

        public ResourceService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<ResourceDto>> GetAllResourcesAsync()
        {
            // Implementation for retrieving all resources
            var resources = new List<ResourceDto>();
            return await Task.FromResult(resources);
        }
    }
}
