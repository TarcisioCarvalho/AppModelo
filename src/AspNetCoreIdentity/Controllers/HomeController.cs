using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("Erro");
            return View();
        }
        
        public IActionResult Secret()
        {
            return View();
        }
        [Authorize(Policy ="PodeExcluir")]
        public IActionResult SecretClaims()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimsPodeEscrever()
        {
            return View();
        }

        [ClaimsAuthorize("Produtos","Ler2")]
        public IActionResult ClaimsCustom()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();
            if(id == 500)
            {
                modelErro.Mensagem = "Ocorreu um Erro! Tente Novamente mais tarde!";
                modelErro.Titulo = "Ocorreu um Erro";
                modelErro.ErroCode = id;
            }
            if(id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe";
                modelErro.Titulo = "Página não encontrada";
                modelErro.ErroCode = id;
            }
            if (id == 403)
            {
                modelErro.Mensagem = "Acesso Não Autorizado";
                modelErro.Titulo = "Sem Acesso!";
                modelErro.ErroCode = id;
            }
            return View("Error",modelErro);
        }
    }
}
