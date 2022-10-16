using Dominio.Models;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        Produto GetByID(int id);
        void VincularProdutoNaPromocao(Promocao promocao, int idDoProduto);
    }
}
