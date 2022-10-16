using AppService.Interfaces;
using Dominio.Models;
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
            if (listaProdutosCarrinho.Count == 0)
                return 0;
            
            var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
            if (listaProdutosCarrinho?.Count > 0)
            {
                foreach (var item in listaProdutosCarrinho)
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
            }

            foreach (var item in listaAgrupadaPorProdutoxQuantidade)
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
                    if (produto.Promocao.TipoPromocao == Dominio.Resources.TipoPromocao.LeveDoisPagueUm)
                        valorTotal += (item.Quantidade * produto.Preco) / 2;

                    if (produto.Promocao.TipoPromocao == Dominio.Resources.TipoPromocao.TresPorDez && item.Quantidade == 3)
                    {
                        valorTotal += 10;
                    }
                }
            }

            return valorTotal;
        }
    }
}
