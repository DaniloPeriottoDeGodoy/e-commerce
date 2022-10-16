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

        public Carrinho ObterCarrinho() => _carrinho;
    }
}
