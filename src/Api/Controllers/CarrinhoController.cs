using AppService.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoApplicationService _carrinhoApplicationService;

        public CarrinhoController(ICarrinhoApplicationService carrinhoApplicationService) => _carrinhoApplicationService = carrinhoApplicationService;

        [HttpPost("Item")]
        public void AdicionarItem(Item item)
        {
            try
            {
                _carrinhoApplicationService.AdicionarProdutoNoCarrinho(item);
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
                _carrinhoApplicationService.LimparCarrinho();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("Total")]
        public decimal ObterTotalDoCarrinho()
        {
            decimal valorTotal;
            try
            {
                valorTotal = _carrinhoApplicationService.ObterValorTotalCarrinho();
            }
            catch (Exception)
            {
                throw;
            }

            return valorTotal;
        }
    }
}
