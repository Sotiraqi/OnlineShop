using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private ApplicationDbContext _db;
        private IWebHostEnvironment _he;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index() => View(_db.products?.Include(c => c.productCategory).ToList());

        //POST Index action method
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.products?.Include(c => c.productCategory)
                .Where(c => c.productPrice >= lowAmount && c.productPrice <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                products = _db.products?.Include(c => c.productCategory).ToList();
            }
            return View(products);
        }

        //Get Create method
        public IActionResult Create()
        {
            ViewData["productCategoryId"] = new SelectList(_db.productCategories?.ToList(), "categoryId", "categoryName");
            return View();
        }


        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(product product, IFormFile image)
        {
            //if (ModelState.IsValid)
            
            ModelState.ClearValidationState(nameof(product));
            if (!TryValidateModel(product, nameof(product)))
            {
                var searchProduct = _db.products?.FirstOrDefault(c => c.productName == product.productName);
                if (searchProduct != null)
                {
                    ViewBag.message = "This product is already exist";
                    ViewData["productCategoryId"] = new SelectList(_db.productCategories?.ToList(), "categoryId", "categoryName");
                    return View(product);
                }

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.productImage = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.productImage = "Images/noimage.PNG";
                }
                _db.products?.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["productCategoryId"] = new SelectList(_db.productCategories?.ToList(), "categoryId", "categoryName");
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.products?.Include(c => c.productCategory).FirstOrDefault(c => c.productId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(product product, IFormFile image)
        {
            //if (ModelState.IsValid)
            ModelState.ClearValidationState(nameof(product));
            if (!TryValidateModel(product, nameof(product)))
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.productImage = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.productImage = "Images/noimage.PNG";
                }
                _db.products?.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        //GET Details Action Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.products?.Include(c => c.productCategory).FirstOrDefault(c => c.productId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.products?.Include(c => c.productCategory).Where(c => c.productId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Delete Action Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.products?.FirstOrDefault(c => c.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.products?.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
