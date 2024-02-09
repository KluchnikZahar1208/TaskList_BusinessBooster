using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class AddTaskListCommandHandler : IRequestHandler<AddTaskListCommand, int>
    {
        private readonly ITaskListRepository _taskListRepository;

        public AddTaskListCommandHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<int> Handle(AddTaskListCommand request, CancellationToken cancellationToken)
        {
            var taskList = new TaskList
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId
            };

            return await _taskListRepository.AddTaskListAsync(taskList);
        }
    }
}
