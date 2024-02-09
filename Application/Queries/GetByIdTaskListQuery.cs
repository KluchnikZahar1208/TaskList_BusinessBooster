using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Queries
{
    public class GetByIdTaskListQuery : IRequest<TaskList>
    {
        public int TaskListId { get; }

        public GetByIdTaskListQuery(int taskListId)
        {
            TaskListId = taskListId;
        }
    }
}
