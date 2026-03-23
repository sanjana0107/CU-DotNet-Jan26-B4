using AutoMapper;
using LoanManagmentAPI_with_DTO.DTOs.Create;
using LoanManagmentAPI_with_DTO.DTOs.Get;
using LoanManagmentAPI_with_DTO.DTOs.Update;
using LoanManagmentAPI_with_DTO.Models;

namespace LoanManagmentAPI_with_DTO.Mappings
{
    public class MappingProfile  : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDTO, Loan>();
            CreateMap<UpdateDto, Loan>();

            CreateMap<Loan, ReadDto>();
        }
    }
}
