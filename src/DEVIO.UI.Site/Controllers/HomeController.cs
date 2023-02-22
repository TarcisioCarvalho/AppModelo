using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEVIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }
    }
}
