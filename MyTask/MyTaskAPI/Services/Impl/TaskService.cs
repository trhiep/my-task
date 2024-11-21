using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTaskAPI.Models.DTOs;
using MyTaskAPI.Repositories;
using TaskAppModel = MyTaskAPI.Models.Task;

namespace MyTaskAPI.Services.Impl
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskAppModel?> AddTaskAsync(TaskCreateDto taskCreateDto)
        {
            var taskToAdd = _mapper.Map<TaskAppModel>(taskCreateDto);
            taskToAdd.CreatedDate = DateTime.Now;
            
            var addedTask = await _taskRepository.AddTaskAsync(taskToAdd);
            if (addedTask != null)
            {
                return addedTask;
            }
            return null;
        }

        public async Task<ActionResult> DeleteTaskAsync(int id)
        {
            var deleteTask = await _taskRepository.GetTaskByIdAsync(id);
            if (deleteTask != null)
            {
                var deleteResult = await _taskRepository.DeleteTaskAsync(deleteTask);
                if (deleteResult > 0)
                {
                    return new NoContentResult();
                }

                return new ConflictResult();
            }

            return new NotFoundResult();
        }

        public async Task<TaskDto?> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto)
        {
            var thisTask = await _taskRepository.GetTaskByIdAsync(id);
            if (thisTask == null)
            {
                return null;
            }
            
            thisTask = _mapper.Map(taskUpdateDto, thisTask);
            var updatedTask = await _taskRepository.UpdateTaskAsync(thisTask);
            if (updatedTask > 0)
            {
                return _mapper.Map<TaskDto>(thisTask);
            }
            return null;
        }

        public async Task<IEnumerable<TaskDto>?> GetAllTaskAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            if (tasks.Any())
            {
                return _mapper.Map<IEnumerable<TaskDto>>(tasks);
            }
            return null;
        }

        public async Task<IEnumerable<TaskDto>?> GetAllTasksOfAnUserAsync(int userId)
        {
            var tasks = await _taskRepository.GetAllTasksOfAnUserAsync(userId);
            if (tasks.Any())
            {
                return _mapper.Map<IEnumerable<TaskDto>>(tasks);
            }
            return null;
        }

        public async Task<TaskDto?> GetATaskAsync(int id)
        {
            var thisTask = await _taskRepository.GetTaskByIdAsync(id);
            if (thisTask != null)
            {
                return _mapper.Map<TaskDto>(thisTask);
            }
            return null;
        }
    }
}
