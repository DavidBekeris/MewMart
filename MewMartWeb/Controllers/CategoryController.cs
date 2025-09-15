using Microsoft.AspNetCore.Mvc;

namespace MewMartWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
