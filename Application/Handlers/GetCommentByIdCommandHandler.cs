using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetCommentByIdCommandHandler : IRequestHandler<GetCommentByIdCommand, TaskComment>
    {
        private readonly ITaskCommentRepository _commentRepository;

        public GetCommentByIdCommandHandler(ITaskCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<TaskComment> Handle(GetCommentByIdCommand request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetCommentByIdAsync(request.CommentId);
        }
    }
}
