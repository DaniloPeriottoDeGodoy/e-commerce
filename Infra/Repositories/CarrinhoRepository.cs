using Dominio.Interfaces;
using Dominio.Models;
using System.Collections.Generic;

namespace Infra.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private static Carrinho _carrinho { get; set; }

        public CarrinhoRepository()
        {
            if (_carrinho == null)
                _carrinho = new Carrinho();
        }

        public void AdicionarProdutoCarrinho(Item produtoCarrinho)
        {
            _carrinho.ListaProdutosCarrinho.Add(produtoCarrinho);
        }

        public void LimparCarrinho()
        {
            _carrinho.ListaProdutosCarrinho = new List<Item>();
        }

        public List<Item> ObterProdutosCarrinho()
        {
            return _carrinho?.ListaProdutosCarrinho;
        }
    }
}
