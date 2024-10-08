using MusicShop.Models.UserDTO;
using MusicShop.Models;

namespace MusicShop.Repository.IRepository
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        Task LoginUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
        // Task AssignUserRole(int id, string role);
        Task ResetPasswordAsync(int id, string password);
        Task DeleteUserAsync(User user);
    }
}
