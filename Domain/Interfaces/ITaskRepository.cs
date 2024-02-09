namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<Entities.Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Entities.Task>> GetAllTasksAsync();
        Task<int> AddTaskAsync(Entities.Task task);
        Task UpdateTaskAsync(Entities.Task task);
        Task DeleteTaskAsync(int id);
    }
}
