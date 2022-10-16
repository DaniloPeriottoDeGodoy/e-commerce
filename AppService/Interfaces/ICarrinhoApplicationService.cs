using Dominio.Models;

namespace AppService.Interfaces
{
    public interface ICarrinhoApplicationService
    {
        void AdicionarProdutoNoCarrinho(Item item);
        void LimparCarrinho();
        decimal ObterValorTotalCarrinho();
    }
}
