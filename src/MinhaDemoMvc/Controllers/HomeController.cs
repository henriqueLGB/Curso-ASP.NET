using Microsoft.AspNetCore.Mvc;
using MinhaDemoMvc.Models;
using System.Diagnostics;

namespace MinhaDemoMvc.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {

        [Route("")]
        [Route("pagina-inicial/{id:int}/{code:guid}")]
        public IActionResult Index(int id , Guid code)
        {
            /*
             * VAMOS CRIAR UM INSTÂNCIA PARA ESSA CLASSE JUSTAMENTE 
             * PARA DEMOSTRAR OS CAMPOS DE VALIDAÇÃO
             */
            var filme = new Filme()
            {
                Titulo = "Oi",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };

            return RedirectToAction("ListaFilmes",filme);
            //return View();
        }

        [Route("lista-filmes")]
        public IActionResult ListaFilmes(Filme filme)
        {
            //VERIFICA A VALIDAÇÃO DA MODEL PASSADA
            if (ModelState.IsValid)
            {

            }

            //PERCORRE OS ERROS DO MODEL , VALIDANDO ATRAVÉS DO QUE ESPECIFICAMOS NA 
            //PRÓPRIA MODEL
            foreach(var erro in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(erro.ErrorMessage);
            }

            return View();
        }

        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            //No caso como o retorno é IActionResult temos que retornar alguma ação , abaixo alguns exemplos
            //return Json("{'nome':'Henrique'}");
            //var fileBytes = System.IO.File.ReadAllBytes(@"F:\arquivo.txt");
            //var fileName = "arquivo.txt";
            //return File(fileBytes,System.Net.Mime.MediaTypeNames.Application.Octet,fileName);
            //return PartialView();
            //return Content("Qualquer coisa");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}