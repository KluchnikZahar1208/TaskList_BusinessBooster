using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Queries
{
    public class GetTaskStatusHistoryByTaskIdQuery : IRequest<IEnumerable<TaskStatusHistory>>
    {
        public int TaskId { get; set; }

        public GetTaskStatusHistoryByTaskIdQuery(int taskId)
        {
            TaskId = taskId;
        }
    }
}
