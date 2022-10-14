using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface IPromocaoRepository
    {
        Promocao ObterPromocaoPorId(int idDaPromocao);
    }
}
