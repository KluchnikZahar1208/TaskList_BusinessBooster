using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, Unit>
    {
        private readonly ITaskListRepository _taskListRepository;

        public DeleteTaskListCommandHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<Unit> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            var taskList = await _taskListRepository.GetTaskListByIdAsync(request.Id);

            if (taskList == null)
            {
                throw new Exception($"Task list with ID {request.Id} not found.");
            }

            await _taskListRepository.DeleteTaskListAsync(taskList.Id);

            return Unit.Value;
        }
    }
}
