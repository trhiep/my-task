using MyTaskAPI.MappingProfiles;
using MyTaskAPI.Repositories;
using MyTaskAPI.Repositories.Impl;
using MyTaskAPI.Services;
using MyTaskAPI.Services.Impl;

namespace MyTaskAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add mapper
            services.AddAutoMapper(typeof(TaskMappings));
            services.AddAutoMapper(typeof(StepMappings));

            // Add repositories
            services.AddScoped<ITaskRepository, TaskRepository>();

            // Add services
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
