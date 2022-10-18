using AppService.Interfaces;
using Dominio.DTO.Carrinho.AdicionarItem;
using Dominio.DTO.Carrinho.LimparCarrinho;
using Dominio.DTO.Carrinho.ObterValorCarrinho;
using Dominio.Models;
using Dominio.Services;

namespace AppService.Services
{
    public class CarrinhoApplicationService : ICarrinhoApplicationService
    {
        private readonly CarrinhoService _carrinhoService;
        private readonly ProdutoService _produtoService;

        public CarrinhoApplicationService(CarrinhoService carrinhoService, ProdutoService produtoService)
        {
            _carrinhoService = carrinhoService;
            _produtoService = produtoService;
        }

        public DtoAdicionarItemResponse AdicionarProdutoNoCarrinho(DtoAdicionarItemRequest dtoRequest)
        {
            DtoAdicionarItemResponse dtoResponse = new DtoAdicionarItemResponse();

            if (dtoRequest == null)
            {
                dtoResponse.AdicionarErro("Dto inválido.");
                return dtoResponse;
            }

            if (dtoRequest.IdDoProduto == 0)
                dtoResponse.AdicionarErro("Não foi informado um código de produto válido.");

            if (dtoRequest.Quantidade == 0)
                dtoResponse.AdicionarErro("Quantidade do produto não pode ser igual a zero.");

            if (dtoResponse.PossuiErros)
                return dtoResponse;

            Produto produto = _produtoService.ObterProdutoPorId(dtoRequest.IdDoProduto);
            if (produto == null)
            {
                dtoResponse.AdicionarErro("Produto não encontrado.");
                return dtoResponse;
            }

            if (produto != null)
            {
                var carrinho = _carrinhoService.ObterCarrinho();
                carrinho.AdicionarProdutoNoCarrinho(produto, dtoRequest.Quantidade);
                dtoResponse.Carrinho = carrinho;
            }

            return dtoResponse;
        }

        public DtoLimparCarrinhoResponse LimparCarrinho()
        {
            DtoLimparCarrinhoResponse dtoResponse = new DtoLimparCarrinhoResponse();

            var carrinho = _carrinhoService.ObterCarrinho();
            carrinho.LimparCarrinho();

            dtoResponse.Carrinho = carrinho;
            return dtoResponse;
        }

        public DtoObterValorCarrinhoResponse ObterValorTotalCarrinho()
        {
            DtoObterValorCarrinhoResponse dtoResponse = new DtoObterValorCarrinhoResponse();

            Carrinho carrinho = _carrinhoService.ObterCarrinho();
            dtoResponse.ValorTotal = carrinho.ObterValorTotalCarrinho();

            return dtoResponse;
        }
    }
}
