using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly ITaskCommentRepository _commentRepository;

        public UpdateCommentCommandHandler(ITaskCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var existingComment = await _commentRepository.GetCommentByIdAsync(request.CommentId);

            if (existingComment == null)
            {
                throw new ArgumentException($"Comment with ID {request.CommentId} not found.");
            }

            existingComment.Comment = request.NewComment;

            await _commentRepository.UpdateCommentAsync(existingComment);

            return Unit.Value;
        }
    }
}
