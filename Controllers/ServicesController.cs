using AutoMapper;
using BooknGo.Data.Models;
using BooknGo.DTOs;
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
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDTO>> GetAllServices()
        {
            var services = _serviceService.GetAllServices();
            var serviceDTOs = _mapper.Map<IEnumerable<ServiceDTO>>(services);
            return Ok(serviceDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceDTO> GetServiceById(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            var serviceDTO = _mapper.Map<ServiceDTO>(service);
            return Ok(serviceDTO);
        }

        [HttpPost]
        public ActionResult<ServiceDTO> AddService(ServiceDTO serviceDTO)
        {
            var service = _mapper.Map<Service>(serviceDTO);
            var newService = _serviceService.AddService(service);
            var newServiceDTO = _mapper.Map<ServiceDTO>(newService);
            return CreatedAtAction(nameof(GetServiceById), new { id = newServiceDTO.ServiceId }, newServiceDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, ServiceDTO updatedServiceDTO)
        {
            var updatedService = _mapper.Map<Service>(updatedServiceDTO);
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
