namespace Dominio.DTO.Produto
{
    public class DtoVincularPromocaoAoProdutoRequest
    {
        public DtoVincularPromocaoAoProdutoRequest(int idDaPromocao, int idDoProduto)
        {
            IdDaPromocao = idDaPromocao;
            IdDoProduto = idDoProduto;
        }

        public int IdDaPromocao { get; set; }
        public int IdDoProduto { get; set; }
    }
}
