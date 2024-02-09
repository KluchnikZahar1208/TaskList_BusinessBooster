using TaskList_BusinessBooster.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface ITaskListRepository
    {
        Task<TaskList> GetTaskListByIdAsync(int id);
        Task<IEnumerable<TaskList>> GetAllTaskListsAsync();
        Task<int> AddTaskListAsync(TaskList taskList);
        Task UpdateTaskListAsync(TaskList taskList);
        Task DeleteTaskListAsync(int id);
    }
}
