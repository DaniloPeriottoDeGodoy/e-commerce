using Dominio.Interfaces;
using Dominio.Models;
using System.Collections.Generic;

namespace Dominio.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _repository;

        public CarrinhoService(ICarrinhoRepository repository) => _repository = repository;        

        public Carrinho ObterCarrinho() => _repository.ObterCarrinho();
    }
}
