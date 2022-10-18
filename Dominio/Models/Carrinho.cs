using Dominio.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Models
{
    public class Carrinho : Base
    {
        #region Construtor

        public Carrinho() => this.ListaItensCarrinho = new List<Item>();

        #endregion

        #region Propriedades

        public List<Item> ListaItensCarrinho { get; set; }
        public bool CarrinhoEstaVazio { get { return this.ListaItensCarrinho?.Count == 0; } }
        public bool CarrinhoPossuiItens { get { return this.ListaItensCarrinho != null && this.ListaItensCarrinho.Any(); } }

        #endregion

        #region Funções privadas

        private List<Item> AgruparQuantidadePorProduto()
        {
            var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
            if (this.CarrinhoPossuiItens)
            {
                foreach (var item in this.ListaItensCarrinho)
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
                    else
                    {
                        listaAgrupadaPorProdutoxQuantidade.Add(item);
                        continue;
                    }
                }
            }

            return listaAgrupadaPorProdutoxQuantidade;
        }

        private decimal CalcularValorSemPromocao(int quantidade, decimal preco) => (quantidade * preco);

        private decimal CalcularValorComPromocao(Item item)
        {
            decimal valorTotal = 0;

            int quantidadeMinima = item.ObterQuantidadeMinimaParaAplicarPromocao();
            var quantidadeTotalDesseProduto = item.Quantidade;

            while (quantidadeTotalDesseProduto > 0)
            {
                if (quantidadeTotalDesseProduto >= quantidadeMinima)
                {                    
                    if (item.ObterTipoPromocao() == TipoPromocao.LeveDoisPagueUm)
                        valorTotal += (quantidadeMinima * item.Produto.Preco) / 2;

                    if (item.ObterTipoPromocao() == TipoPromocao.TresPorDez)
                        valorTotal += 10;

                    quantidadeTotalDesseProduto -= quantidadeMinima;
                }
                else
                {                    
                    valorTotal += CalcularValorSemPromocao(quantidadeTotalDesseProduto, item.Produto.Preco);
                    quantidadeTotalDesseProduto -= quantidadeTotalDesseProduto;
                }
            }
            return valorTotal;
        }

        #endregion

        #region Funções

        public void LimparCarrinho() => this.ListaItensCarrinho = new List<Item>();

        public void AdicionarProdutoNoCarrinho(Produto produto, int quantidade) => this.ListaItensCarrinho.Add(new Item(produto, quantidade));

        public decimal ObterValorTotalCarrinho()
        {
            decimal valorTotal = 0;

            if (this.CarrinhoEstaVazio)
                return 0;

            List<Item> listaAgrupadaPorProdutoxQuantidade = this.AgruparQuantidadePorProduto();
            foreach (var item in listaAgrupadaPorProdutoxQuantidade)
            {                
                if (item.Quantidade == 0)
                    continue;

                if (!item.PossuiPromocao)
                {
                    valorTotal += CalcularValorSemPromocao(item.Quantidade, item.Produto.Preco);
                }
                else
                {
                    valorTotal += CalcularValorComPromocao(item);
                }
            }

            return valorTotal;
        }

        #endregion
    }
}
