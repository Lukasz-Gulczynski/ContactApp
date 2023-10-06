using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Core.Models
{
    public class Contact
    {
        [Column("ContactId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Contact name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the surname is 30 characters.")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the email is 50 characters.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pasword is a required field.")]
        [MinLength(8, ErrorMessage = "Minimum length for the password is 8 characters.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the password is 50 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Category is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the category is 20 characters.")]
        [Display(Name = "Category")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birthdate is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Birthdate is 20 characters.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
