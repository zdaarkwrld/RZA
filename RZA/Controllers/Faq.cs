using Microsoft.AspNetCore.Mvc;

namespace RZA.Controllers
{
    public class Faq : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
