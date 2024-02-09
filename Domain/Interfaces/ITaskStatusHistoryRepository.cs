using TaskList_BusinessBooster.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface ITaskStatusHistoryRepository
    {
        Task<IEnumerable<TaskStatusHistory>> GetAllAsync();
        Task<TaskStatusHistory> GetByIdAsync(int id);
        Task<IEnumerable<TaskStatusHistory>> GetByTaskIdAsync(int taskId);
        Task<int> AddAsync(TaskStatusHistory statusHistory);
        Task UpdateAsync(TaskStatusHistory statusHistory);
        Task DeleteAsync(int id);
    }
}
