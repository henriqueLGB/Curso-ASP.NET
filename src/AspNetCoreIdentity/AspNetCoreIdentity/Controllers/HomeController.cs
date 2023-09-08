using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            _logger.LogInformation("Usuário Acessou a home!");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Secret()
        {
            return View();
        }

        //Utilizando Claims
        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        //CLAIM CUSTOMIZADO
        [ClaimsAuthorizeAttribute("Produtos", "Ler")]
        public IActionResult ClaimCustom()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            switch (id)
            {
                case 500:
                    modelErro.Mensagem = "Ocorreu um erro ! Tente novamente mais tarde ou contate nosso suporte";
                    modelErro.Titulo = "Ocorreu um erro !";
                    modelErro.ErrorCode = id;
                    break;
                case 404:
                    modelErro.Mensagem = "A Página que está procurando não existe ! <br /> Em caso de dúvida entre em contato com o suporte !";
                    modelErro.Titulo = "Ooops Página não encontrada !";
                    modelErro.ErrorCode = id;
                    break;

                case 403:
                    modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                    modelErro.Titulo = "Acesso Negado !";
                    modelErro.ErrorCode = id;
                    break;

                default:
                    return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}