using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetTaskStatusHistoryByTaskIdQueryHandler : IRequestHandler<GetTaskStatusHistoryByTaskIdQuery, IEnumerable<TaskStatusHistory>>
    {
        private readonly ITaskStatusHistoryRepository _repository;

        public GetTaskStatusHistoryByTaskIdQueryHandler(ITaskStatusHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskStatusHistory>> Handle(GetTaskStatusHistoryByTaskIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByTaskIdAsync(request.TaskId);
        }
    }
}
