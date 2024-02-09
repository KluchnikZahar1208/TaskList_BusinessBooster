using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetAllTaskStatusHistoryQueryHandler : IRequestHandler<GetAllTaskStatusHistoryQuery, IEnumerable<TaskStatusHistory>>
    {
        private readonly ITaskStatusHistoryRepository _repository;

        public GetAllTaskStatusHistoryQueryHandler(ITaskStatusHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskStatusHistory>> Handle(GetAllTaskStatusHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
