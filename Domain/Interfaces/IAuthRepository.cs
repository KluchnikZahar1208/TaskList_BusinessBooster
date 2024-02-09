using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> LoginAsync(UserDTO userDTO);
        Task<bool> RegistrationAsync(UserDTO userDTO);
    }
}
