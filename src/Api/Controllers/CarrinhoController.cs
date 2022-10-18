using AppService.Interfaces;
using Dominio.DTO.Carrinho.AdicionarItem;
using Dominio.DTO.Carrinho.LimparCarrinho;
using Dominio.DTO.Carrinho.ObterValorCarrinho;
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

        /// <summary>
        /// EndPoint para adicionar um novo item ao carrinho.
        /// </summary>
        /// <param name="dtoRequest"> Dto contendo o IdDoProduto e a Quantidade</param>
        /// <returns>Retorna um DTO com o Carrinho no estado atual.</returns>
        [HttpPost("Item")]
        public DtoAdicionarItemResponse AdicionarItem(DtoAdicionarItemRequest dtoRequest)
        {
            DtoAdicionarItemResponse dtoResponse = new DtoAdicionarItemResponse();
            try
            {                
                dtoResponse = _carrinhoApplicationService.AdicionarProdutoNoCarrinho(dtoRequest);
                return dtoResponse;
            }
            catch (Exception e)
            {
                dtoResponse.AdicionarErro($"Ocorreu um erro ao adicionar item ao carrinho. Erro: {e.Message}");
                return dtoResponse;
            }
        }

        /// <summary>
        /// Endpoint para limpar o carrinho.
        /// </summary>
        /// <returns>Retorna um dto com o estado atual do carrinho</returns>
        [HttpPost("LimparCarrinho")]
        public DtoLimparCarrinhoResponse LimparCarrinho()
        {
            DtoLimparCarrinhoResponse dtoResponse = new DtoLimparCarrinhoResponse();
            try
            {
                dtoResponse = _carrinhoApplicationService.LimparCarrinho();
                return dtoResponse;
            }
            catch (Exception e)
            {
                dtoResponse.AdicionarErro($"Ocorreu um erro ao limpar o carrinho. Erro: {e.Message}");
                return dtoResponse;
            }
        }

        /// <summary>
        /// EndPoint para obter o valor total do carrinho.
        /// </summary>
        /// <returns>Retorna um DTO contendo o valor total calculado.</returns>
        [HttpGet("Total")]
        public DtoObterValorCarrinhoResponse ObterTotalDoCarrinho()
        {
            DtoObterValorCarrinhoResponse dtoResponse = new DtoObterValorCarrinhoResponse();
            
            try
            {
                dtoResponse = _carrinhoApplicationService.ObterValorTotalCarrinho();
                return dtoResponse;
            }
            catch (Exception e)
            {
                dtoResponse.AdicionarErro($"Ocorreu um erro ao obter o valor total do carrinho. Erro: {e.Message}");
                return dtoResponse;
            }
        }
    }
}
