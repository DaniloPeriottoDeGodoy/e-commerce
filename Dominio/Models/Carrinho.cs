using System.Collections.Generic;

namespace Dominio.Models
{
    public class Carrinho : Base
    {        

        //public Carrinho() => this.ListaProdutosCarrinho = new List<ProdutoCarrinho>();

        public List<Item> ListaProdutosCarrinho { get; set; }
    }
}
