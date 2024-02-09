using MediatR;

namespace TaskList_BusinessBooster.Application.Queries
{
    public class GetAllTasksQuery : IRequest<IEnumerable<Domain.Entities.Task>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string FilterBy { get; set; }
    }
}
