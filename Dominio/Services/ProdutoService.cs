using Dominio.Interfaces;
using Dominio.Models;
using System;

namespace Dominio.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) => _repository = repository;

        public Produto ObterProdutoPorId(int id) => _repository.ObterPorId(id);
    }
}
