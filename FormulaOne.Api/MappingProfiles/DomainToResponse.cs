using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievement, GetDriverAchievementDto>()
            .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.RaceWins));

        CreateMap<Driver, GetDriverDto>()
            .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
            );
    }
}
