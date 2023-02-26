using Microsoft.AspNetCore.Mvc;

namespace DEVIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
