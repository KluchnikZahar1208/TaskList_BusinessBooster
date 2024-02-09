using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class AddTaskStatusHistoryCommandHandler : IRequestHandler<AddTaskStatusHistoryCommand, int>
    {
        private readonly ITaskStatusHistoryRepository _repository;

        public AddTaskStatusHistoryCommandHandler(ITaskStatusHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddTaskStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            var statusHistory = new TaskStatusHistory
            {
                TaskId = request.TaskId,
                OldStatus = request.OldStatus,
                NewStatus = request.NewStatus,
                DateChanged = request.DateChanged
            };

            return await _repository.AddAsync(statusHistory);
        }
    }
}
