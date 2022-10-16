using AppService.Interfaces;
using Dominio.Models;
using Dominio.Resources;
using Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AdicionarProdutoNoCarrinho(Item item)
        {
            Produto produto = _produtoService.ObterProdutoPorId(item.IdDoProduto);
            if (produto != null)
            {
                var carrinho = _carrinhoService.ObterCarrinho();
                carrinho.AdicionarProdutoNoCarrinho(produto, item.Quantidade);
            }
        }

        public void LimparCarrinho()
        {
            var carrinho = _carrinhoService.ObterCarrinho();
            carrinho.LimparCarrinho();
        }

        public decimal ObterValorTotalCarrinho()
        {
            Carrinho carrinho = _carrinhoService.ObterCarrinho();            
            return carrinho.ObterValorTotalCarrinho();
        }
    }
}
