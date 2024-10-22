using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IMapper _mapper;
        private readonly List<ResourceDto> _resources;

        public ResourceService(IMapper mapper)
        {
            _mapper = mapper;
            _resources = new List<ResourceDto>(); // Mocked in-memory data store
        }

        public async Task<IList<ResourceDto>> GetAllResourcesAsync()
        {
            return await Task.FromResult(_resources);
        }

        public async Task<ResourceDto> GetResourceByIdAsync(Guid id)
        {
            var resource = _resources.FirstOrDefault(r => r.Id == id);
            return await Task.FromResult(resource);
        }

        public async Task<ResourceDto> CreateResourceAsync(ResourceDto resourceDto)
        {
            resourceDto.Id = Guid.NewGuid();
            _resources.Add(resourceDto);
            return await Task.FromResult(resourceDto);
        }

        public async Task<ResourceDto> UpdateResourceAsync(Guid id, ResourceDto resourceDto)
        {
            var existingResource = _resources.FirstOrDefault(r => r.Id == id);
            if (existingResource == null)
            {
                return null;
            }

            existingResource.Name = resourceDto.Name;
            existingResource.Description = resourceDto.Description;
            existingResource.Location = resourceDto.Location;

            return await Task.FromResult(existingResource);
        }

        public async Task<bool> DeleteResourceAsync(Guid id)
        {
            var resource = _resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                return await Task.FromResult(false);
            }

            _resources.Remove(resource);
            return await Task.FromResult(true);
        }
    }
}
