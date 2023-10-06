using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Core.Models
{
    public class RegisteredUser
    {
        [Column("RegisteresUserId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters.")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the email is 50 characters.")]
        public string? Email { get; set; }
    }
}
