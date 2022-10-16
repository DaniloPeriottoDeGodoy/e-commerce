using Dominio.Interfaces;
using Dominio.Models;
using System;

namespace Dominio.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) => _repository = repository;

        public Produto ObterProdutoPorId(int id)
        {
            try
            {
                return _repository.ObterPorId(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
