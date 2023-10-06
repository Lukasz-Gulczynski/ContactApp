using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Core.Dtos
{
    public class UserRegistrationDto
    {
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }
    }
}
