using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetUserByEmailCommandHandler : IRequestHandler<GetUserByEmailCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByEmailAsync(request.UserEmail);
        }
    }
}
