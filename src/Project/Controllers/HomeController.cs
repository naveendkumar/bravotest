using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}