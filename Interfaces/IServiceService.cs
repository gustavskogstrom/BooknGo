using BooknGo.Data.Models;

namespace BooknGo.Interfaces
{
    public interface IServiceService
    {
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(int id);
        Service AddService(Service service);
        bool UpdateService(int id, Service updatedService);
        bool DeleteService(int id);
    }
}
