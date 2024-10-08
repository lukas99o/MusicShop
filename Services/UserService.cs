using Microsoft.IdentityModel.Tokens;
using MusicShop.Models;
using MusicShop.Models.UserDTO;
using MusicShop.Repository.IRepository;
using MusicShop.Services.IServices;

namespace MusicShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterUserAsync(UserRegistrationDTO registrationDTO)
        {
            var user = new User
            {
                Email = registrationDTO.Email,
                Password = registrationDTO.Password
            };

            await _repository.RegisterUserAsync(user);
        }

        public async Task<IEnumerable<UserGetDTO>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            var userList = users.Select(user => new UserGetDTO
            {
                Id = user.Id,
                Email = user.Email
            }).ToList();

            return userList;
        }

        public async Task<UserGetDTO> GetUserByIdAsync(int id)
        {
            var userFound = await _repository.GetUserByIdAsync(id);

            if (userFound != null)
            {
                var user = new UserGetDTO
                {
                    Id = userFound.Id,
                    Email = userFound.Email
                };

                return user;
            }

            return null; 
        }

        public async Task<bool> UpdateUserAsync(UserUpdateDTO updateDTO)
        {
            if (string.IsNullOrEmpty(updateDTO.Email))
            {
                return false;
            }

            var user = await _repository.GetUserByIdAsync(updateDTO.Id);

            if (user != null)
            {
                user.Email = updateDTO.Email;
                await _repository.UpdateUserAsync(user);

                return true;
            }

            return false; 
        }

        public async Task LoginUserAsync(UserLoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetPasswordAsync(int id, string password)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user != null)
            {
                user.Password = password;
                await _repository.UpdateUserAsync(user);

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user != null)
            {
                await _repository.DeleteUserAsync(user);
                return true;
            }

            return false; 
        }
    }
}
