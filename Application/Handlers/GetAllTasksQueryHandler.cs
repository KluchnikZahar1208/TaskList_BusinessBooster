using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<Domain.Entities.Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            if (!string.IsNullOrEmpty(request.FilterBy))
            {
                tasks = tasks.Where(t => t.Title.Contains(request.FilterBy) || t.Description.Contains(request.FilterBy));
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy.ToLower())
                {
                    case "title":
                        tasks = tasks.OrderBy(t => t.Title);
                        break;
                    case "description":
                        tasks = tasks.OrderBy(t => t.Description);
                        break;
                    case "createdAt":
                        tasks = tasks.OrderBy(t => t.CreatedAt);
                        break;
                    case "status":
                        tasks = tasks.OrderBy(t => t.Status);
                        break;
                    default:
                        tasks = tasks.OrderBy(t => t.Id);
                        break;
                }
            }

            tasks = tasks.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

            return tasks;
        }
    }
}
