using Microsoft.AspNetCore.Mvc;

namespace RZA.Controllers
{
    public class ResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
