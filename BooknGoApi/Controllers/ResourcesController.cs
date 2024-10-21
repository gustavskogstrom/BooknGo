using AutoMapper;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;

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
}
