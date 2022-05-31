using Microsoft.AspNetCore.Mvc;

namespace SPV.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
