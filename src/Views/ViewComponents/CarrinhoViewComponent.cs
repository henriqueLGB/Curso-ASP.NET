using Microsoft.AspNetCore.Mvc;

namespace Views.ViewComponents
{
    [ViewComponent(Name = "Carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        public int ItensCarrinho { get; set; }

        public CarrinhoViewComponent()
        {
            //SIMULANDO UM RETORNO DO BANCO DE DADOS
            ItensCarrinho = 1;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensCarrinho);
        }
    }
}
