using MediatR;

namespace TaskList_BusinessBooster.Application.Queries
{
    public class GetAllClearTasksQuery : IRequest<IEnumerable<Domain.Entities.Task>>
    {
    }
}
