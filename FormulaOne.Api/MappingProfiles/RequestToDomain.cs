﻿using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOne.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementDto, Achievement>()
            .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateDriverAchievementDto, Achievement>()
            .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateDriverDto, Driver>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateDriverDto, Driver>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DriverId))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
