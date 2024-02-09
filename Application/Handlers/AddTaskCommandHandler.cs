using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskListRepository _taskListRepository;

        public AddTaskCommandHandler(ITaskRepository taskRepository, ITaskListRepository taskListRepository)
        {
            _taskRepository = taskRepository;
            _taskListRepository = taskListRepository;
        }

        public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var taskLists = await _taskListRepository.GetAllTaskListsAsync();
            if (taskLists.FirstOrDefault(l => l.Id == request.TaskListId) == null)
            {
                throw new Exception("TaskList not found");
            }
            var newTask = new Domain.Entities.Task
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.Now.ToString(), 
                TaskListId = request.TaskListId, 
                Status = Domain.Entities.Task.Statuses[0]
            };

            await _taskRepository.AddTaskAsync(newTask);

            return newTask.Id;
        }
    }
}
