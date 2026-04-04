using TravelDestinationAPI.Models;

namespace TravelDestinationAPI.Repository
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllAsync();

        Task<Destination> GetByIdAsync(int id);

        Task<Destination> AddAsync(Destination destination);

        Task<Destination> UpdateAsync(Destination destination);

        Task DeleteAsync(int id);
    }
}
