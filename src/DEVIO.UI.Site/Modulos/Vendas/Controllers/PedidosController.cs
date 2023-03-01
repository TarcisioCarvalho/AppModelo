using Microsoft.AspNetCore.Mvc;

namespace DEVIO.UI.Site.Modulos.Vendas.Controllers
{
    [Area("Vendas")]
    [Route("Vendas")]
    public class PedidosController : Controller
    {
        [Route("Pedidos")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
