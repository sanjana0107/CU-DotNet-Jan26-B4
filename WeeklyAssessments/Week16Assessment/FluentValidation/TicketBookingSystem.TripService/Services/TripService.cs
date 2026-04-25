using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.TripService.DTOs;
using TicketBookingSystem.TripService.Exceptions;
using TicketBookingSystem.TripService.Models;
using AutoMapper;

using TicketBookingSystem.TripService.Repositories;

namespace TicketBookingSystem.TripService.Services
{    
    public class TripService : ITripService
    {
        private readonly ITripRepository _repository;
        private readonly HttpClient _itineraryhttp;
        private readonly ILogger<TripService> _logger;
        private readonly IMapper _mapper;

        public TripService(ITripRepository repository, IHttpClientFactory clientFactory, ILogger<TripService> logger, IMapper mapper)
        {
            _repository = repository;
            _itineraryhttp = clientFactory.CreateClient("ItineraryService");
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<TripWithItineraryDto> GetTripByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching trip with ID {id}");
            var trip = await _repository.GetByIdAsync(id);

            if (trip == null)
            {
                _logger.LogWarning($"Trip with trip Id {id} not found");
                throw new NotFoundException($"Trip with ID {id} not found");
            }

            List<ItineraryItemDto> itinerary;

            try
            {
                itinerary = await _itineraryhttp
                    .GetFromJsonAsync<List<ItineraryItemDto>>($"api/itinerary/trip/{id}")
                    ?? new();
                _logger.LogInformation($"Fetched itinerary for trip id {id}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error fetching itinerary for trip id{id}");
                itinerary = new(); // fallback if service fails
            }
            var tripDto = _mapper.Map<TripWithItineraryDto>(trip);
            tripDto.Itinerary = itinerary;
            return tripDto;        
        }




        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _repository.GetAllAsync();
        }

        //public async Task<Trip> GetTripByIdAsync(int id)
        //{
        //    var trip = await _repository.GetByIdAsync(id);

        //    if (trip == null)
        //        throw new NotFoundException($"Trip with ID {id} not found");

        //    return trip;
        //}

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            _logger.LogInformation($"Creating new trip with {trip.Heading}");
            await _repository.AddAsync(trip);
            _logger.LogInformation($"Trip created with id {trip.Id}");
            return trip;
        }

        public async Task UpdateTripAsync(int id, Trip trip)
        {
            if (id != trip.Id)
            {
                _logger.LogWarning($"trip id mismatch {id} vs {trip.Id}");
                throw new BadRequestException("Trip ID mismatch");
            }

            if (!await _repository.ExistsAsync(id))
            {
                _logger.LogWarning($"trip with id {id} not found for update");
                throw new NotFoundException($"Trip with ID {id} not found");
            }

            try
            {
                await _repository.UpdateAsync(trip);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, $"Concurrency issue while updating trip with {id}");
                throw new Exception("Concurrency error occurred while updating trip");
            }
        }

        public async Task DeleteTripAsync(int id)
        {
            var trip = await _repository.GetByIdAsync(id);

            if (trip == null)
            {
                _logger.LogWarning($"trip with id {id} not found for deletion");
                throw new NotFoundException($"Trip with ID {id} not found");
            }

            await _repository.DeleteAsync(trip);
            _logger.LogInformation($"trip deleted : {id}");
        }
    }
}