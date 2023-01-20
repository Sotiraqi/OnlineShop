using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Extensions;
using OnlineShop.Models;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;
        private DateTime _returnDate = DateTime.MinValue;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Checkout actioin method

        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(order anOrder)
        {
            List<product> products = HttpContext.Session.Get<List<product>>("product");
            if (products != null)
            {
                foreach (var product in products)
                {
                    orderDetail orderDetails = new orderDetail();
                    orderDetails.productId = product.productId;                    
                    anOrder.orderDetails.Add(orderDetails);
                }
            }

            anOrder.orderDate = ReturnDate;
            anOrder.orderNr = GetOrderNo();
            _db.orders!.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("product", new List<product>());
            return View();
        }


        public string GetOrderNo()
        {
            int rowCount = _db.orders!.ToList().Count() + 1;
            return rowCount.ToString("000");
        }

        public DateTime ReturnDate
        {
            get
            {
                return (_returnDate == DateTime.MinValue) ? DateTime.Now : _returnDate;
            }
            set { _returnDate = value; }
        }
    }
}
