using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface IPromocaoRepository
    {
        Promocao ObterPorId(int idDaPromocao);
    }
}
