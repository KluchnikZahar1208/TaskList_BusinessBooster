using MediatR;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<TaskComment>>
    {
        private readonly ITaskCommentRepository _commentRepository;

        public GetAllCommentsQueryHandler(ITaskCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<TaskComment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAllCommentsAsync();
        }
    }
}
