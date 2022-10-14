using Dominio.Interfaces;
using Dominio.Models;
using System;

namespace Dominio.Services
{
    public class PromocaoService
    {
        private readonly IPromocaoRepository _repository;

        public PromocaoService(IPromocaoRepository repository)
        {
            _repository = repository;
        }

        public Promocao ObterPromocaoPorId(int idDaPromocao)
        {
            return _repository.ObterPromocaoPorId(idDaPromocao);
        }
    }
}
