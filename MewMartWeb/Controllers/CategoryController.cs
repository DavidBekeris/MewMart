using MewMart.DataAccess.Data;
using MewMart.DataAccess.Repository.IRepository;
using MewMart.Models;
using Microsoft.AspNetCore.Mvc;

namespace MewMartWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Bara för att testa!
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("", "Kategori namn och visnings order kan inte vara samma.");
            //}
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Kategorin har blivit skapad!";
                return RedirectToAction("Index", "Category"); // Can change category to other controller if another view should be used
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Kategorin har blivit redigerad!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if ( obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Kategorin har blivit raderad!";
            return RedirectToAction("Index", "Category");
        }
    }
}
