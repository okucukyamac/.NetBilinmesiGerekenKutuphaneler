using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategory()
        {
            return Ok(new { Id = 1, Category = "Kırtasiye" });
        }

        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new { Status = "Success" });
        }
    }
}
