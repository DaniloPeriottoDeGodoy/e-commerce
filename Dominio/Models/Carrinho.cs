using Dominio.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Models
{
    public class Carrinho : Base
    {
        #region Construtor

        public Carrinho() => this.ListaProdutosCarrinho = new List<Item>();

        #endregion

        #region Propriedades

        public List<Item> ListaProdutosCarrinho { get; set; }

        public bool CarrinhoVazio { get { return this.ListaProdutosCarrinho?.Count == 0; } }
        public bool CarrinhoPossuiItens { get { return this.ListaProdutosCarrinho != null && this.ListaProdutosCarrinho.Any(); } }

        #endregion

        #region Funções privadas

        private List<Item> AgruparQuantidadePorProduto()
        {
            var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
            if (this.CarrinhoPossuiItens)
            {
                foreach (var item in this.ListaProdutosCarrinho)
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

            return listaAgrupadaPorProdutoxQuantidade;
        }

        #endregion

        #region Funções

        public void LimparCarrinho() => this.ListaProdutosCarrinho = new List<Item>();

        public void AdicionarProdutoNoCarrinho(Produto produto, int quantidade) => this.ListaProdutosCarrinho.Add(new Item(produto, quantidade));

        public decimal ObterValorTotalCarrinho()
        {
            decimal valorTotal = 0;

            if (this.CarrinhoVazio)
                return 0;

            List<Item> listaAgrupadaPorProdutoxQuantidade = this.AgruparQuantidadePorProduto();
            foreach (var item in listaAgrupadaPorProdutoxQuantidade)
            {                
                if (item.Produto == null)
                    throw new Exception("Produto não encontrado.");

                if (!item.Produto.PossuiPromocao)
                {
                    valorTotal += (item.Quantidade * item.Produto.Preco);
                }
                else
                {
                    if (item.Produto.Promocao.TipoPromocao == TipoPromocao.LeveDoisPagueUm)
                        valorTotal += (item.Quantidade * item.Produto.Preco) / 2;

                    if (item.Produto.Promocao.TipoPromocao == TipoPromocao.TresPorDez && item.Quantidade == 3)
                    {
                        valorTotal += 10;
                    }
                }
            }

            return valorTotal;
        }

        #endregion
    }
}
