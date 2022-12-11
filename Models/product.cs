using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Models
{
    public class product
    {
        
        public int productId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string? productName { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal productPrice { get; set; }
        public string? productImage { get; set; }
        [Display(Name = "Product Color")]
        public string? productColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Product Category")]
        [Required]
        public int productCategoryId { get; set; }
        [ForeignKey("productCategoryId")]
        public virtual productCategory? productCategory { get; set; }        
    }
}
