namespace AppService.Interfaces
{
    public interface ICarrinhoApplicationService
    {
        void AdicionarProdutoNoCarrinho(int idDoProduto, int quantidade);
        void LimparCarrinho();
        decimal ObterValorTotalCarrinho();
    }
}
