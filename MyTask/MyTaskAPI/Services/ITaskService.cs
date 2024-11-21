using Microsoft.AspNetCore.Mvc;
using MyTaskAPI.Models.DTOs;
using TaskAppModel = MyTaskAPI.Models.Task;

namespace MyTaskAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>?> GetAllTaskAsync();
        Task<IEnumerable<TaskDto>?> GetAllTasksOfAnUserAsync(int userId);
        Task<TaskDto?> GetATaskAsync(int id);
        Task<TaskAppModel?> AddTaskAsync(TaskCreateDto taskCreateDto);
        Task<ActionResult> DeleteTaskAsync(int id);
        Task<TaskDto?> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto);
    }
}
