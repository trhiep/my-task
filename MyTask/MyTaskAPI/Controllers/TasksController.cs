using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTaskAPI.Data;
using MyTaskAPI.Models;
using MyTaskAPI.Models.DTOs;
using MyTaskAPI.Services;

namespace MyTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTaskAsync();
            if (tasks != null)
            {
                return Ok(tasks);
            }

            return NotFound();
        }
        
        // GET: api/Tasks/user/1
        [HttpGet]
        [Route("/user/{userId:int}", Name = nameof(GetAllTasksOfAnUser))]
        public async Task<ActionResult<TaskDto>> GetAllTasksOfAnUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest();
            }

            var tasks = await _taskService.GetAllTasksOfAnUserAsync(userId);
            if (tasks != null)
            {
                return Ok(tasks);
            }

            return NotFound();
        }
        
        // GET: api/Tasks/1
        [HttpGet]
        [Route("{id:int}", Name = nameof(GetATask))]
        public async Task<ActionResult<TaskDto>> GetATask(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            
            var task = await _taskService.GetATaskAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/Tasks
        [HttpPost(Name = nameof(AddTask))]
        public async Task<ActionResult<TaskDto>> AddTask([FromBody] TaskCreateDto? taskCreateDto)
        {
            if (taskCreateDto == null)
            {
                return BadRequest();
            }
            
            var addedTask = await _taskService.AddTaskAsync(taskCreateDto);
            if (addedTask != null)
            {
                return CreatedAtAction(nameof(GetATask), new { id = addedTask.TaskId }, addedTask);
            }

            return Conflict();
        }
        
        // PUT: api/Tasks/1
        [HttpPut("{id:int}", Name = nameof(UpdateTask))]
        public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] TaskUpdateDto taskUpdateDto)
        {
            if (id != taskUpdateDto.TaskId || id <= 0)
            {
                return BadRequest();
            }
            
            var updatedTask = await _taskService.UpdateTaskAsync(id, taskUpdateDto);
            if (updatedTask != null)
            {
                return Ok(updatedTask);
            }

            return Conflict();
        }
        
        // DELETE: api/Tasks/1
        [HttpDelete]
        [Route("{id:int}", Name = nameof(DeleteTask))]
        public async Task<ActionResult> DeleteTask(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            
            return await _taskService.DeleteTaskAsync(id);
        }
    }
}
