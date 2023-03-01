using DEVIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;

namespace DEVIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
