using AppService.Interfaces;
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

        public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
        {
            var produto = _produtoService.ObterProdutoPorId(idDoProduto);
            if (produto == null)
                throw new Exception("Código de produto não encontrado.");

            var promocao = _promocaoService.ObterPromocaoPorId(idDaPromocao);
            if (promocao == null)
                throw new Exception("Código de promoção não encontrado.");

            _produtoService.VincularProdutoNaPromocao(promocao, idDoProduto);
        }
    }
}
