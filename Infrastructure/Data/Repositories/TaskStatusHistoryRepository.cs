using Microsoft.EntityFrameworkCore;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Infrastructure.Data.Repositories
{
    public class TaskStatusHistoryRepository : ITaskStatusHistoryRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskStatusHistoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskStatusHistory>> GetAllAsync()
        {
            return await _dbContext.TaskStatusHistory.ToListAsync();
        }

        public async Task<TaskStatusHistory> GetByIdAsync(int id)
        {
            return await _dbContext.TaskStatusHistory.FindAsync(id);
        }

        public async Task<IEnumerable<TaskStatusHistory>> GetByTaskIdAsync(int taskId)
        {
            return await _dbContext.TaskStatusHistory.Where(history => history.TaskId == taskId).ToListAsync();
        }

        public async Task<int> AddAsync(TaskStatusHistory statusHistory)
        {
            _dbContext.TaskStatusHistory.Add(statusHistory);
            await _dbContext.SaveChangesAsync();
            return statusHistory.Id;
        }

        public async Task UpdateAsync(TaskStatusHistory statusHistory)
        {
            _dbContext.Entry(statusHistory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var history = await _dbContext.TaskStatusHistory.FindAsync(id);
            if (history != null)
            {
                _dbContext.TaskStatusHistory.Remove(history);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
