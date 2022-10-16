using System;
using System.Collections.Generic;

namespace Dominio.Models
{
    public class Carrinho : Base
    {
        #region Construtor

        public Carrinho() => this.ListaProdutosCarrinho = new List<Item>();

        #endregion

        #region Propriedades

        public List<Item> ListaProdutosCarrinho { get; set; }

        #endregion

        #region Funções

        public void LimparCarrinho() => this.ListaProdutosCarrinho = new List<Item>();

        public void AdicionarProdutoNoCarrinho(int idDoProduto, int quantidade)
        {
            if (idDoProduto > 0 && quantidade > 0)
                this.ListaProdutosCarrinho.Add(new Item(idDoProduto, quantidade));
        }

        #endregion

    }
}
