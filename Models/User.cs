using System.ComponentModel.DataAnnotations;

namespace MusicShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        // public string Role { get; set; }
    }
}
