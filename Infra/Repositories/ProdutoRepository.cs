using Dominio.Interfaces;
using Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static readonly List<Produto> ListaProdutos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "PS5", Preco = 50 },
            new Produto { Id = 2, Nome = "TV do Edi 32 polegadas (Modelo 2002)", Preco = 30 },
            new Produto { Id = 3, Nome = "Sanfona do Buxin", Preco = 10 }
        };

        public Produto ObterPorId(int id) => ListaProdutos?.FirstOrDefault(x => x.Id == id);
    }
}
