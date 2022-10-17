using AppService.Interfaces;
using Dominio.DTO.Produto;
using Dominio.Services;
using System;

namespace AppService.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly PromocaoService _promocaoService;
        private readonly ProdutoService _produtoService;

        public ProdutoApplicationService(PromocaoService promocaoService, ProdutoService produtoService)
        {
            _promocaoService = promocaoService;
            _produtoService = produtoService;
        }

        public DtoVincularPromocaoAoProdutoResponse VincularPromocaoAoProduto(DtoVincularPromocaoAoProdutoRequest dtoRequest)
        {
            DtoVincularPromocaoAoProdutoResponse response = new DtoVincularPromocaoAoProdutoResponse();

            var produto = _produtoService.ObterProdutoPorId(dtoRequest.IdDoProduto);
            if (produto == null)
                response.AdicionarErro("Produto não encontrado.");

            var promocao = _promocaoService.ObterPromocaoPorId(dtoRequest.IdDaPromocao);
            if (promocao == null)
                response.AdicionarErro("Promoção não encontrada.");

            if (response.PossuiErros)
                return response;

            produto.VincularPromocao(promocao);

            response.IdProduto = produto.Id;
            response.IdPromocao = promocao.Id;
            response.NomeDoProduto = produto.Nome;
            response.NomePromocao = promocao.Descricao;
            response.Preco = produto.Preco;

            return response;
        }
    }
}
