using AppService.Interfaces;
using Dominio.Models;
using Dominio.Services;
using System;

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

        public void AdicionarProdutoNoCarrinho(int idDoProduto, int quantidade)
        {
            Produto produto = _produtoService.ObterProdutoPorId(idDoProduto);
            if (produto != null)
                _carrinhoService.AdicionarProdutoNoCarrinho(idDoProduto, quantidade);
        }

        public void LimparCarrinho()
        {
            _carrinhoService.LimparCarrinho();
        }

        public decimal ObterValorTotalCarrinho()
        {
            decimal valorTotal = 0;

            var listaProdutosCarrinho = _carrinhoService.ObterProdutosCarrinho();
            foreach (var item in listaProdutosCarrinho)
            {
                var produto = _produtoService.ObterProdutoPorId(item.IdDoProduto);
                if (produto == null)
                    throw new Exception("Código do produto não encontrado");

                if (produto.Promocao == null || produto.Promocao.Id == 0)
                {
                    valorTotal += (item.Quantidade * produto.Preco);
                }
                else
                {
                    valorTotal += (item.Quantidade * produto.Preco) / 2;
                }
            }

            return valorTotal;
        }
    }
}
