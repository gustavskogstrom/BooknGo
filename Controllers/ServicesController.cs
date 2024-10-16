using BooknGo.Data.Models;
using BooknGo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooknGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAllServices()
        {
            return Ok(_serviceService.GetAllServices());
        }

        [HttpGet("{id}")]
        public ActionResult<Service> GetServiceById(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public ActionResult<Service> AddService(Service service)
        {
            var newService = _serviceService.AddService(service);
            return CreatedAtAction(nameof(GetServiceById), new { id = newService.ServiceId }, newService);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            if (!_serviceService.UpdateService(id, updatedService))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            if (!_serviceService.DeleteService(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
