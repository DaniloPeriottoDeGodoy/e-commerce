using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface IProdutoRepository
    {        
        Produto ObterPorId(int id);        
    }
}
