using AutoMapper;
using TicketBookingSystem.TripService.DTOs;
using TicketBookingSystem.TripService.Models;
using TicketBookingSystem.TripService.DTOs;
using TicketBookingSystem.TripService.Models;


namespace TicketBookingSystem.TripService.Mappings
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripWithItineraryDto>();
            //CreateMap<Trip, Trip>().ReverseMap();
        }
    }
}
