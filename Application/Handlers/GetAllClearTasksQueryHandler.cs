using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetAllClearTasksQueryHandler : IRequestHandler<GetAllClearTasksQuery, IEnumerable<Domain.Entities.Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllClearTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> Handle(GetAllClearTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks;
        }
    }
}
