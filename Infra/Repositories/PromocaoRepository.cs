using Dominio.Interfaces;
using Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private List<Promocao> _promocoes { get; set; }

        public PromocaoRepository()
        {
            if (_promocoes == null)
            {
                _promocoes = new List<Promocao>
                {
                    new Promocao
                    {
                        Id = 1,
                        Descricao= "Leve 2 e Pague 1"
                    },
                    new Promocao
                    {
                        Id = 2,
                        Descricao= "3 por R$10,00"
                    }
                };
            }
        }

        public Promocao ObterPromocaoPorId(int idDaPromocao)
        {
            if (_promocoes?.Count > 0)
            {
                return _promocoes.FirstOrDefault(x => x.Id == idDaPromocao);
            }

            return null;
        }
    }
}
