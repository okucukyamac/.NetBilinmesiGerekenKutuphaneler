using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    public class CategoriesController : ControllerBase
    {
        [Route("api/[controller]")]

        [HttpGet]
        public IActionResult GetCategory()
        
        {
            return Ok(new { Id = 1, Category = "Kırtasiye" });
        }

        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new { Status = "Success" });
        }

        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }

    }
}
