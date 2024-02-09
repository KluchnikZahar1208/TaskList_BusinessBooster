using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<User> UpdateUserProfile(int userId, UserDTO user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
