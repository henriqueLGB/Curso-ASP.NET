using DEMO.App.Data;
using Microsoft.AspNetCore.Mvc;

namespace DEMO.App.Controllers
{
    public class HomeController : Controller
    {
        //FORMA MAIS RECOMENDADA PARA FAZER A INJEÇÃO DE DEPÊNCENCIAS
        //private readonly IPedidoRepository _pedidoRepository;

        //public HomeController(IPedidoRepository pedidoRepository)
        //{
        //    _pedidoRepository = pedidoRepository;
        //}

        //OUTRA FORMA DE FAZER A INJEÇÃO DE DEPÊNDENCIAS (Não recomendado)
        public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
        {
            //var pedido = _pedidoRepository.ObterPedido();
            return View();
        }
    }
}
 