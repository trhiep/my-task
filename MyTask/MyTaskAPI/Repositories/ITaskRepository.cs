
using TaskAppModel = MyTaskAPI.Models.Task;
namespace MyTaskAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskAppModel>> GetAllTasksAsync();
        Task<IEnumerable<TaskAppModel>> GetAllTasksOfAnUserAsync(int userId);
        Task<TaskAppModel?> GetTaskByIdAsync(int id);
        Task<TaskAppModel?> AddTaskAsync(TaskAppModel task);
        Task<Int32> UpdateTaskAsync(TaskAppModel task);
        Task<Int32> DeleteTaskAsync(TaskAppModel deleteTask);
    }
}
