using Microsoft.EntityFrameworkCore;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;


namespace TaskList_BusinessBooster.Infrastructure.Data.Repositories
{
    public class TaskListRepository: ITaskListRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskListRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskList> GetTaskListByIdAsync(int id)
        {
            return await _dbContext.TaskLists.FindAsync(id);
        }

        public async Task<IEnumerable<TaskList>> GetAllTaskListsAsync()
        {
            return await _dbContext.TaskLists.ToListAsync();
        }

        public async Task<int> AddTaskListAsync(TaskList taskList)
        {
            _dbContext.TaskLists.Add(taskList);
            await _dbContext.SaveChangesAsync();
            return taskList.Id;
        }

        public async Task UpdateTaskListAsync(TaskList taskList)
        {
            _dbContext.Entry(taskList).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskListAsync(int id)
        {
            var taskList = await _dbContext.TaskLists.FindAsync(id);
            if (taskList != null)
            {
                _dbContext.TaskLists.Remove(taskList);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
