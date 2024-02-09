using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetByIdTaskListQueryHandler : IRequestHandler<GetByIdTaskListQuery, TaskList>
    {
        private readonly ITaskListRepository _taskListRepository;

        public GetByIdTaskListQueryHandler(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<TaskList> Handle(GetByIdTaskListQuery request, CancellationToken cancellationToken)
        {
            return await _taskListRepository.GetTaskListByIdAsync(request.TaskListId);
        }
    }
}
