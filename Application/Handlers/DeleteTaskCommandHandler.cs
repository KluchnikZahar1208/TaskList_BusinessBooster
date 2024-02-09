using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteTaskAsync(request.TaskId);
            return Unit.Value;
        }
    }
}
