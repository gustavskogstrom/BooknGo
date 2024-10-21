using AutoMapper;
using BooknGoApi.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AvailabilitiesController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;
    private readonly ILogger<AvailabilitiesController> _logger;
    private readonly IMapper _mapper;

    public AvailabilitiesController(IAvailabilityService availabilityService, ILogger<AvailabilitiesController> logger, IMapper mapper)
    {
        _availabilityService = availabilityService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAvailabilities()
    {
        var availabilities = await _availabilityService.GetAllAvailabilitiesAsync();
        if (availabilities == null || availabilities.Count == 0)
        {
            _logger.LogWarning("No availabilities found.");
            return NotFound("No availabilities found.");
        }
        return Ok(availabilities);
    }
}
