using TravelDestination.MVC.Models;

namespace TravelDestination.MVC.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();

        Task CreateAsync(Destination destination);
        
        
    }
}
