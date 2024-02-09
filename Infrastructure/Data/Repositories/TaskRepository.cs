using Microsoft.EntityFrameworkCore;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddTaskAsync(Domain.Entities.Task task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task.Id;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetTaskByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task UpdateTaskAsync(Domain.Entities.Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
