namespace Dominio.Models
{
    public class Item
    {
        public Item(int idDoProduto, int quantidade)
        {
            IdDoProduto = idDoProduto;
            Quantidade = quantidade;
        }

        public Item()
        {

        }
        public int IdDoProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
