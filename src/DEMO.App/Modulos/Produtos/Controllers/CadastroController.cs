using Microsoft.AspNetCore.Mvc;

namespace DEMO.App.Areas.Produtos.Controllers
{
    [Area("Produtos")]
    [Route("pedidos")]
    public class CadastroController : Controller
    {
        [Route("listar")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Busca()
        {
            return View();
        }
    }
}
