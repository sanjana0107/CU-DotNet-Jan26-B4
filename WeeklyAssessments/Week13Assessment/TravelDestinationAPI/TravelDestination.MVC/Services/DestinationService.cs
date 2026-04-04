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

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var response = await _client.GetAsync("api/destinations");

            return await response.Content.ReadFromJsonAsync<IEnumerable<Destination>>() ?? [];
        }


        public async Task CreateAsync(Destination destination)
        {
            await _client.PostAsJsonAsync($"api/destinations", destination);
        }
    }
}
