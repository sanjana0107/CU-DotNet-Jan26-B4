using AutoMapper;
using NorthWind.Services.Models;
using NorthWind.Services.DTOs;

namespace NorthWind.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" + src.CategoryName + ".jpg"));

            CreateMap<Product, ProductDto>();
        }

    }
}
