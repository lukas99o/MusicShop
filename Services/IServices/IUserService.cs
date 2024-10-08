using MusicShop.Models;
using MusicShop.Models.UserDTO;

namespace MusicShop.Services.IServices
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegistrationDTO registrationDTO);
        Task LoginUserAsync(UserLoginDTO loginDTO);
        Task<IEnumerable<UserGetDTO>> GetUsersAsync();
        Task<UserGetDTO> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(UserUpdateDTO updateDTO);
        // Task AssignUserRole(int id, string role);
        Task<bool> ResetPasswordAsync(int id, string password);
        Task<bool> DeleteUserAsync(int id);
    }
}
