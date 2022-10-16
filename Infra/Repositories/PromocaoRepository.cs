using Dominio.Interfaces;
using Dominio.Models;
using Dominio.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private static readonly List<Promocao> _promocoes = new List<Promocao>
        {
            new Promocao { Id = 1, Descricao = "Leve 2 e Pague 1", TipoPromocao = TipoPromocao.LeveDoisPagueUm},
            new Promocao { Id = 2, Descricao = "3 por R$10,00", TipoPromocao = TipoPromocao.TresPorDez},
        };

        public PromocaoRepository()
        {
            
        }

        public Promocao ObterPorId(int idDaPromocao) => _promocoes?.FirstOrDefault(x => x.Id == idDaPromocao);
    }
}
