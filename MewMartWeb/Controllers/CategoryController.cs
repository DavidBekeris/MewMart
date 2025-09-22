using MewMartWeb.Data;
using MewMartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MewMartWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Kategori namn och visnings order kan inte vara samma.");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Får inte heta test.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category"); // Can change category to other controller if another view should be used
            }
            return View();
        }
    }
}
