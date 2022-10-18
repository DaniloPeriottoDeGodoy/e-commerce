namespace Dominio.DTO.Produto
{
    public class DtoVincularPromocaoAoProdutoResponse : DtoResponseBase
    {
        public int IdProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public decimal Preco { get; set; }
        public int IdPromocao { get; set; }
        public string NomePromocao { get; set; }

    }
}
