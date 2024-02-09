using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, Unit>
    {
        private readonly ITaskListRepository _taskListRepository;

        public UpdateTaskListCommandHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<Unit> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            var existingTaskList = await _taskListRepository.GetTaskListByIdAsync(request.Id);

            if (existingTaskList == null)
            {
                throw new Exception($"Task list with ID {request.Id} not found.");
            }

            existingTaskList.Title = request.Title;
            existingTaskList.Description = request.Description;

            await _taskListRepository.UpdateTaskListAsync(existingTaskList);

            return Unit.Value;
        }
    }
}
