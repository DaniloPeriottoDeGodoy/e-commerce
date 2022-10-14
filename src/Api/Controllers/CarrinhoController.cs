using Dominio.Models;
using Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        private readonly CarrinhoService _carrinhoService;

        public CarrinhoController(ProdutoService produtoService, CarrinhoService carrinhoService)
        {
            _produtoService = produtoService;
            _carrinhoService = carrinhoService;
        }

        [HttpPost("Item")]
        public void AdicionarItem(Item item)
        {
            try
            {
                Produto produto = _produtoService.ObterProdutoPorId(item.IdDoProduto);
                if (produto != null)
                    _carrinhoService.AdicionarProdutoNoCarrinho(item.IdDoProduto, item.Quantidade);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("LimparCarrinho")]
        public void LimparCarrinho()
        {
            try
            {
                _carrinhoService.LimparCarrinho();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("Total")]
        public decimal ObterTotalDoCarrinho()
        {
            decimal valorTotal = 0;

            try
            {
                var listaProdutosCarrinho = _carrinhoService.ObterProdutosCarrinho();
                foreach (var item in listaProdutosCarrinho)
                {
                    var produto = _produtoService.ObterProdutoPorId(item.IdDoProduto);
                    if (produto == null)
                        throw new Exception("Código do produto não encontrado");

                    if (produto.Promocao == null || produto.Promocao.Id == 0)
                    {
                        valorTotal += (item.Quantidade * produto.Preco);
                    }
                    else
                    {
                        valorTotal += (item.Quantidade * produto.Preco) / 2;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return valorTotal;
        }


        // Email: edimarcos.maranhao@siteware.com.br
    }
}
