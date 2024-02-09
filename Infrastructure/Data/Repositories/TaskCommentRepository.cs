using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;


namespace TaskList_BusinessBooster.Infrastructure.Data.Repositories
{
    public class TaskCommentRepository : ITaskCommentRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskCommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskComment>> GetAllCommentsAsync()
        {
            return await _dbContext.TaskComments.ToListAsync();
        }

        public async Task<TaskComment> GetCommentByIdAsync(int id)
        {
            return await _dbContext.TaskComments.FindAsync(id);
        }

        public async Task<int> AddCommentAsync(TaskComment taskComment)
        {
            _dbContext.TaskComments.Add(taskComment);
            await _dbContext.SaveChangesAsync();
            return taskComment.Id;
        }

        public async Task UpdateCommentAsync(TaskComment taskComment)
        {
            _dbContext.Entry(taskComment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var taskComment = await _dbContext.TaskComments.FindAsync(id);
            if (taskComment != null)
            {
                _dbContext.TaskComments.Remove(taskComment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskComment>> GetCommentByTaskIdAsync(int taskId)
        {
            return await _dbContext.TaskComments.Where(c => c.TaskId == taskId).ToListAsync();
        }

    }
}
