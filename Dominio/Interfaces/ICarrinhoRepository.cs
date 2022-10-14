using Dominio.Models;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface ICarrinhoRepository
    {
        void AdicionarProdutoCarrinho(Item produtoCarrinho);
        void LimparCarrinho();
        List<Item> ObterProdutosCarrinho();
    }
}
