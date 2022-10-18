using Dominio.DTO.Carrinho.AdicionarItem;
using Dominio.DTO.Carrinho.LimparCarrinho;
using Dominio.DTO.Carrinho.ObterValorCarrinho;

namespace AppService.Interfaces
{
    public interface ICarrinhoApplicationService
    {
        DtoAdicionarItemResponse AdicionarProdutoNoCarrinho(DtoAdicionarItemRequest dtoRequest);
        DtoLimparCarrinhoResponse LimparCarrinho();
        DtoObterValorCarrinhoResponse ObterValorTotalCarrinho();
    }
}
