using Dominio.Models;

namespace Dominio.DTO.Carrinho.AdicionarItem
{
    public class DtoAdicionarItemRequest
    {
        public int IdDoProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
