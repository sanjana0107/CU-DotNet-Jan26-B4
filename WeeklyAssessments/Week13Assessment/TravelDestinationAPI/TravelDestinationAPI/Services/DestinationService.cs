using Microsoft.AspNetCore.Http.HttpResults;
using TravelDestinationAPI.Models;
using TravelDestinationAPI.Repository;
using TravelDestinationAPI.DTOs;

namespace TravelDestinationAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Destination> AddAsync(CreateDestinationDto dto)
        {
            var destination = new Destination()
            {
                Country = dto.Country,
                CityName = dto.CityName,
                Description = dto.Description,
                Rating = dto.Rating,
                LastVisited = DateTime.Now
            };

             return await _repository.AddAsync(destination);            
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
                throw new Exception("Destination not found");
            await _repository.DeleteAsync(id);
           

        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return  await _repository.GetAllAsync();

        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
                throw new Exception("Destination not found");
            return data;
        }

        public async Task<Destination> UpdateAsync(UpdateDestinationDto dto)
        {
            var data = await _repository.GetByIdAsync(dto.Id);
            if (data == null)
                throw new Exception("Destination not found");
            data.CityName = dto.CityName;
            data.Rating = dto.Rating;
            data.Description = dto.Description;
            data.Country = dto.Country;
            return await _repository.UpdateAsync(data);
            
        }
    }
}
