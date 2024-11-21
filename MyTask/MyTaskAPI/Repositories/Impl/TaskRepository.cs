
using Microsoft.EntityFrameworkCore;
using MyTaskAPI.Data;
using TaskAppModel = MyTaskAPI.Models.Task;

namespace MyTaskAPI.Repositories.Impl
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskAppModel?> AddTaskAsync(TaskAppModel task)
        {
            _dbContext.Tasks.Add(task);
            int result = await _dbContext.SaveChangesAsync();
            if (result != 0)
            {
                return task;
            }
            return null;
        }

        public async Task<Int32> DeleteTaskAsync(TaskAppModel deleteTask)
        {
            _dbContext.Tasks.Remove(deleteTask);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskAppModel>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks
                .Include(x => x.Steps).ToListAsync();
        }

        public async Task<IEnumerable<TaskAppModel>> GetAllTasksOfAnUserAsync(int userId)
        {
            return await _dbContext.Tasks
                .Where(t => t.UserId == userId)
                .Include(x => x.Steps)
                .ToListAsync();
        }

        public async Task<TaskAppModel?> GetTaskByIdAsync(int id)
        {
            return await _dbContext.Tasks
                .Where(t => t.TaskId == id)
                .Include(x => x.Steps)
                .FirstOrDefaultAsync();
        }

        public async Task<Int32> UpdateTaskAsync(TaskAppModel task)
        {
            _dbContext.Tasks.Update(task);
            return await _dbContext.SaveChangesAsync();
        }

        private bool IsTaskExists(int id)
        {
            return (_dbContext.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
