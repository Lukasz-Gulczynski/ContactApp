using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Core.Models
{
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is a required field.")]
        public string CategoryName { get; set; }

        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }
    }
}
