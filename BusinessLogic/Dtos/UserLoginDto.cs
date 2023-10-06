using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Core.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
