using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ContactsApp.Core.Models
{
    public class Subcategory
    {
        [Column("SubcategoryId")]
        public int SubcategoryId { get; set; }

        [Required(ErrorMessage = "SubcategoryName is a required field.")]
        public string SubcategoryName { get; set; }


    }
}
