using Dominio.Interfaces;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Produto ObterProdutoPorId(int id)
        {
            try
            {
                return _repository.GetByID(id);
            }
            catch (Exception e)
            {
                // Alterar depois para DTO
                throw;
            }

        }

        public void VincularProdutoNaPromocao(int idDaPromocao, int idDoProduto)
        {
            _repository.VincularProdutoNaPromocao(idDaPromocao, idDoProduto);
        }
    }
}
