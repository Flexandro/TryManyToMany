using Microsoft.AspNetCore.Mvc;

namespace AppTest1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
