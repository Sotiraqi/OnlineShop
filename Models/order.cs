using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Models
{
    public class order
    {
        public order()
        {
            orderDetails = new List<orderDetail>();
        }
        public int Id { get; set; }
        [Display(Name = "Order number")]
        public string? orderNr { get; set; }
        [Required]
        public string? orderName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string? phoneNr { get; set; }
        [Required]
        [EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? address { get; set; }

        public DateTime orderDate { get; set; }

        public virtual List<orderDetail> orderDetails { get; set; }
    }
}
