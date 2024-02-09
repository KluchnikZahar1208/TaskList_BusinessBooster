using TaskList_BusinessBooster.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface ITaskCommentRepository
    {
        Task<IEnumerable<TaskComment>> GetAllCommentsAsync();
        Task<TaskComment> GetCommentByIdAsync(int id);
        Task<IEnumerable<TaskComment>> GetCommentByTaskIdAsync(int id);
        Task<int> AddCommentAsync(TaskComment taskComment);
        Task UpdateCommentAsync(TaskComment taskComment);
        Task DeleteCommentAsync(int id);
    }
}
