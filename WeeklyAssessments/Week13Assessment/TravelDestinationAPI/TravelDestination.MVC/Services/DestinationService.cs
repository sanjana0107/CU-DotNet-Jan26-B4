using System.Text.Json;
using TravelDestination.MVC.Models;

namespace TravelDestination.MVC.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _client;

        public DestinationService(HttpClient client)
        {
            _client = client;
            
        }
        //public async Task CreateAsync(Destination destination)
        //{
        //    await _client.GetFromJsonAsync<IEnumerable<Destination>>("api/destinations");
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    await _client.DeleteAsync($"api/destinations/{id}");
        //}

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var response = await _client.GetAsync("api/destinations");


            return await response.Content.ReadFromJsonAsync<IEnumerable<Destination>>() ?? [];
        }

        //public async Task<Destination> GetByIdAsync(int id)
        //{
        //    return await _client.GetFromJsonAsync<Destination>($"api/destinations/{id}");
        //}

        //public async Task UpdateAsync(int id, Destination destination)
        //{
        //    await _client.PatchAsJsonAsync($"api/destinations/{id}", destination);
        //}
    }
}
