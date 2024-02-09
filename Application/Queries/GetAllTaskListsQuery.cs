using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Queries
{
    public class GetAllTaskListsQuery : IRequest<IEnumerable<TaskList>>
    {
    }
}
