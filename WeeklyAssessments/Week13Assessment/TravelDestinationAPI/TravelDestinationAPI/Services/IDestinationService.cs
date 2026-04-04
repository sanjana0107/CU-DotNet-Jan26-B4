using TravelDestinationAPI.DTOs;
using TravelDestinationAPI.Models;

namespace TravelDestinationAPI.Services
{
    public interface IDestinationService
    {
        Task<Destination> AddAsync(CreateDestinationDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<Destination>> GetAllAsync();

        Task<Destination> GetByIdAsync(int id);

        Task<Destination> UpdateAsync(UpdateDestinationDto dto);
    }
}
