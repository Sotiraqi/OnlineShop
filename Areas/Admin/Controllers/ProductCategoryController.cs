using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext? _db;

        public ProductCategoryController(ApplicationDbContext? db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db?.productCategories?.ToList();
            return View(data);
        }

        //GET CREATE method
        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _db?.productCategories?.Add(productCategory);
                await _db!.SaveChangesAsync();
                TempData["save"] = "Product category has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(productCategory);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.productCategories?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(productCategory productCategories)
        {
            if (ModelState.IsValid)
            {
                _db!.Update(productCategories);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product category has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(productCategories);
        }


        //GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.productCategories?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(productCategory productCategories)
        {
            return RedirectToAction(nameof(Index));

        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.productCategories?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, productCategory productCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != productCategories.categoryId)
            {
                return NotFound();
            }

            var productCategory = _db?.productCategories?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db!.Remove(productCategory);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product type has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(productCategory);
        }
    }
}
