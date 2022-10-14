using Dominio.Models;
using Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly PromocaoService _promocaoService;
        private readonly ProdutoService _produtoService;

        public ProdutosController(PromocaoService promocaoService, ProdutoService produtoService)
        {
            _promocaoService = promocaoService;
            _produtoService = produtoService;
        }

        [HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
        public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
        {
            try
            {
                var produto = _produtoService.ObterProdutoPorId(idDoProduto);
                if (produto == null)
                    throw new Exception("Código de produto não encontrado.");

                var promocao = _promocaoService.ObterPromocaoPorId(idDaPromocao);
                if (promocao == null)
                    throw new Exception("Código de promoção não encontrado.");

                _produtoService.VincularProdutoNaPromocao(idDaPromocao, idDoProduto);
                
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
