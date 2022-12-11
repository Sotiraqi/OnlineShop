using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class productCategory
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? categoryName { get; set; }
    }
}
