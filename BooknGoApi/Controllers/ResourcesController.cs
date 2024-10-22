using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BooknGoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly ILogger<ResourcesController> _logger;
        private readonly IMapper _mapper;

        public ResourcesController(IResourceService resourceService, ILogger<ResourcesController> logger, IMapper mapper)
        {
            _resourceService = resourceService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources()
        {
            var resources = await _resourceService.GetAllResourcesAsync();
            if (resources == null || resources.Count == 0)
            {
                _logger.LogWarning("No resources found.");
                return NotFound("No resources found.");
            }
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(Guid id)
        {
            var resource = await _resourceService.GetResourceByIdAsync(id);
            if (resource == null)
            {
                _logger.LogWarning($"Resource with ID {id} not found.");
                return NotFound("Resource not found.");
            }
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] ResourceDto resourceDto)
        {
            if (resourceDto == null)
            {
                _logger.LogError("Invalid resource data.");
                return BadRequest("Resource data is invalid.");
            }

            var createdResource = await _resourceService.CreateResourceAsync(resourceDto);
            return CreatedAtAction(nameof(GetResourceById), new { id = createdResource.Id }, createdResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource(Guid id, [FromBody] ResourceDto resourceDto)
        {
            if (resourceDto == null)
            {
                _logger.LogError("Invalid resource data.");
                return BadRequest("Resource data is invalid.");
            }

            var updatedResource = await _resourceService.UpdateResourceAsync(id, resourceDto);
            if (updatedResource == null)
            {
                return NotFound("Resource not found.");
            }
            return Ok(updatedResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(Guid id)
        {
            var deleted = await _resourceService.DeleteResourceAsync(id);
            if (!deleted)
            {
                return NotFound("Resource not found.");
            }
            return NoContent();
        }
    }
}