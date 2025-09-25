using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MewMart.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Kategori Namn")]
        public string Name { get; set; }

        [DisplayName("Visnings Order")]
        [Range(1,100, ErrorMessage ="Numret måste vara mellan 1 och 100.")]
        public int DisplayOrder { get; set; }
    }
}
