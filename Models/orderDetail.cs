using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Models
{
    public class orderDetail
    {
        public int Id { get; set; }
        [Display(Name = "Order")]
        public int orderId { get; set; }
        [Display(Name = "Product")]
        public int productId { get; set; }
        [Display(Name = "Date")]
        public DateTime ordDate { get; set; }

        [ForeignKey("orderId")]
        public order? Order { get; set; }
        [ForeignKey("productId")]
        public product? Product { get; set; }
        [ForeignKey("ordDate")]
        public DateTime orderDate { get; set; }
    }
}
