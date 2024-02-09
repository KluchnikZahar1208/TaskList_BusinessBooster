using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskListRepository _taskListRepository;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, ITaskListRepository taskListRepository)
        {
            _taskRepository = taskRepository;
            _taskListRepository = taskListRepository;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(request.TaskId);
            var taskLists = await _taskListRepository.GetAllTaskListsAsync();
            if (taskLists.FirstOrDefault(l => l.Id == request.TaskListId) == null)
            {
                throw new Exception("TaskList not found");
            }
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }
            if (!Domain.Entities.Task.Statuses.Contains(request.Status.ToString()))
            {
                throw new Exception("Wrong Status");
            }

            existingTask.Title = request.Title;
            existingTask.Description = request.Description;
            existingTask.Status = request.Status;
            existingTask.TaskListId = request.TaskListId;

            await _taskRepository.UpdateTaskAsync(existingTask);

            return Unit.Value;
        }
    }
}
