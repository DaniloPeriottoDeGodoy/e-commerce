using Dominio.DTO.Produto;

namespace AppService.Interfaces
{
    public interface IProdutoApplicationService
    {
        DtoVincularPromocaoAoProdutoResponse VincularPromocaoAoProduto(DtoVincularPromocaoAoProdutoRequest dtoRequest);
    }
}
