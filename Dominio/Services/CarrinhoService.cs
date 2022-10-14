using Dominio.Interfaces;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _repository;

        public CarrinhoService(ICarrinhoRepository repository)
        {
            _repository = repository;
        }

        public void AdicionarProdutoNoCarrinho(int codigoProduto, int quantidade)
        {
            try
            {
                if (codigoProduto > 0 && quantidade > 0)
                {
                    var produtoCarrinho = new Item(codigoProduto, quantidade);
                    _repository.AdicionarProdutoCarrinho(produtoCarrinho);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void LimparCarrinho()
        {
            _repository.LimparCarrinho();
        }

        public List<Item> ObterProdutosCarrinho()
        {
            return _repository.ObterProdutosCarrinho();
        }
    }
}
