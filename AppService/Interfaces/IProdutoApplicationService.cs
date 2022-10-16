namespace AppService.Interfaces
{
    public interface IProdutoApplicationService
    {
        void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto);
    }
}
