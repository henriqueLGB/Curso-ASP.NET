using DEMO.App.Models;

namespace DEMO.App.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }
    }
        
    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    }

}
