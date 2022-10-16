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

        public void AdicionarProdutoNoCarrinho(int idDoProduto, int quantidade)
        {
            Produto produto = _produtoService.ObterProdutoPorId(idDoProduto);
            if (produto != null)
            {
                var carrinho = _carrinhoService.ObterCarrinho();
                carrinho.AdicionarProdutoNoCarrinho(idDoProduto, quantidade);
            }
        }

        public void LimparCarrinho()
        {
            var carrinho = _carrinhoService.ObterCarrinho();
            carrinho.LimparCarrinho();
        }

        public decimal ObterValorTotalCarrinho()
        {
            decimal valorTotal = 0;

            Carrinho carrinho = _carrinhoService.ObterCarrinho();

            if (carrinho.ListaProdutosCarrinho.Count == 0)
                return 0;

            var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
            foreach (var item in carrinho.ListaProdutosCarrinho)
            {
                // Quando não tem nada adiciona o primeiro produto à lista
                if (listaAgrupadaPorProdutoxQuantidade.Count == 0)
                {
                    listaAgrupadaPorProdutoxQuantidade.Add(item);
                    continue;
                }

                var jaTemEsseProduto = listaAgrupadaPorProdutoxQuantidade.Exists(x => x.IdDoProduto == item.IdDoProduto);
                if (jaTemEsseProduto)
                {
                    listaAgrupadaPorProdutoxQuantidade.FirstOrDefault(x => x.IdDoProduto == item.IdDoProduto).Quantidade += item.Quantidade;
                }
            }

            foreach (var item in listaAgrupadaPorProdutoxQuantidade)
            {
                var produto = _produtoService.ObterProdutoPorId(item.IdDoProduto);
                if (produto == null)
                    throw new Exception("Código do produto não encontrado");

                if (!produto.PossuiPromocao)
                {
                    valorTotal += (item.Quantidade * produto.Preco);
                }
                else
                {
                    if (produto.Promocao.TipoPromocao == TipoPromocao.LeveDoisPagueUm)
                        valorTotal += (item.Quantidade * produto.Preco) / 2;

                    if (produto.Promocao.TipoPromocao == TipoPromocao.TresPorDez && item.Quantidade == 3)
                    {
                        valorTotal += 10;
                    }
                }
            }

            return valorTotal;
        }
    }
}
