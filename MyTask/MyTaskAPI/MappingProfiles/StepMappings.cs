using AutoMapper;
using MyTaskAPI.Models;
using MyTaskAPI.Models.DTOs;

namespace MyTaskAPI.MappingProfiles;

public class StepMappings : Profile
{
    public StepMappings()
    {
        CreateMap<Step, StepDto>().ReverseMap();
        CreateMap<Step, StepCreateDto>().ReverseMap();
    }
}