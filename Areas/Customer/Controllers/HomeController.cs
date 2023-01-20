using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using X.PagedList;
using OnlineShop.Extensions;

namespace OnlineShop.Controllers
{
    [Area("Customer")]
    
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public IActionResult Index(int? page)
        {
            return View(_db.products?.Include(c=>c.productCategory).ToPagedList(page??1,9));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        //GET product detail acation method

        public ActionResult Detail(int? id)
        {
            
            if(id==null)
            {
                return NotFound();
            }

            var product = _db.products?.Include(c => c.productCategory).FirstOrDefault(c => c.productId == id);
            if(product==null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST product detail acation method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {
            List<product>products=new List<product>();
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.products?.Include(c => c.productCategory).FirstOrDefault(c => c.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            products = HttpContext.Session.Get<List<product>>("product");
            if(products==null)
            {
                products=new List<product>();
            }
            products.Add(product);
            HttpContext.Session.Set("product", products);
            return RedirectToAction(nameof(Index));
        }
        //GET Remove action methdo
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<product> products = HttpContext.Session.Get<List<product>>("product");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.productId == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult Remove(int? id)
        {
            List<product> products = HttpContext.Session.Get<List<product>>("product");
            if(products!=null)
            {
                var product = products.FirstOrDefault(c => c.productId == id);
                if(product!=null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //GET product Cart action method

        public IActionResult Cart()
        {
            List<product> products = HttpContext.Session.Get<List<product>>("product");
            if(products==null)
            {
                products=new List<product>();
            }
            return View(products);
        }

    }
}
