using AutoMapper;
using MyTaskAPI.Helpers;
using MyTaskAPI.Models.DTOs;
using TaskAppModel = MyTaskAPI.Models.Task;

namespace MyTaskAPI.MappingProfiles;

public class TaskMappings : Profile
{
    public TaskMappings()
    {
        CreateMap<TaskAppModel, TaskDto>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToFriendlyFormat()))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate.ToFriendlyFormat()))
            .ReverseMap();
        CreateMap<TaskAppModel, TaskCreateDto>().ReverseMap();
        CreateMap<TaskUpdateDto, TaskAppModel>()
            .ForMember(dest => dest.TaskName, 
                opt => opt.MapFrom((src, dest) => src.TaskName ?? dest.TaskName))
            .ForMember(dest => dest.DueDate, 
                opt => opt.MapFrom((src, dest) => src.DueDate ?? dest.DueDate))
            .ForMember(dest => dest.IsCompleted, 
                opt => opt.MapFrom((src, dest) => src.IsCompleted ?? dest.IsCompleted))
            .ForMember(dest => dest.IsImportant, 
                opt => opt.MapFrom((src, dest) => src.IsImportant ?? dest.IsImportant));
    }
}