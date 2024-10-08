using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.UserDTO;
using MusicShop.Services.IServices;

namespace MusicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("registeruser")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _service.RegisterUserAsync(user);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(int id)
        {
            var user = await _service.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("update/user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var result = await _service.UpdateUserAsync(user);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("resetpassword/user")]
        public async Task<IActionResult> ResetPassword(int id, string password)
        {
            var result = await _service.ResetPasswordAsync(id, password);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // public async Task<IActionResult> LoginUser();

        // public async Task<IActionResult> UserRole();

        [HttpDelete]
        [Route("delete/user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUserAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
