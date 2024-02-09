using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetAllTaskListsQueryHandler : IRequestHandler<GetAllTaskListsQuery, IEnumerable<TaskList>>
    {
        private readonly ITaskListRepository _taskListRepository;

        public GetAllTaskListsQueryHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<IEnumerable<TaskList>> Handle(GetAllTaskListsQuery request, CancellationToken cancellationToken)
        {
            return await _taskListRepository.GetAllTaskListsAsync();
        }
    }
}
