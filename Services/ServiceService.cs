using BooknGo.Data.Models;
using BooknGo.Data;
using BooknGo.Interfaces;

namespace BooknGo.Services
{
    public class ServiceService : IServiceService
    {
        private readonly BookNGoDbContext _context;

        public ServiceService(BookNGoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public Service AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return service;
        }

        public bool UpdateService(int id, Service updatedService)
        {
            var service = GetServiceById(id);
            if (service == null)
            {
                return false;
            }

            service.ServiceName = updatedService.ServiceName;
            service.Description = updatedService.Description;
            service.Price = updatedService.Price;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteService(int id)
        {
            var service = GetServiceById(id);
            if (service == null)
            {
                return false;
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return true;
        }
    }
}
