using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class GetUserByEmailCommand : IRequest<User>
    {
        public string UserEmail { get; }

        public GetUserByEmailCommand(string userEmai)
        {
            UserEmail = userEmai;
        }
    }
}
