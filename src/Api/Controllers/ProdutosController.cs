using AppService.Interfaces;
using Dominio.DTO.Produto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService) => _produtoApplicationService = produtoApplicationService;

        /// <summary>
        /// EndPoint para vincular um produto a uma promoção.
        /// </summary>
        /// <param name="idDaPromocao">Id de uma promoção existente</param>
        /// <param name="idDoProduto">Id de um produto existente</param>
        /// <returns>Retorna um DTO contendo informações do produto e da promoção. </returns>
        [HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
        public DtoVincularPromocaoAoProdutoResponse VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
        {
            DtoVincularPromocaoAoProdutoResponse dtoResponse = new DtoVincularPromocaoAoProdutoResponse();

            try
            {
                var dtoRequest = new DtoVincularPromocaoAoProdutoRequest(idDaPromocao, idDoProduto);
                dtoResponse = _produtoApplicationService.VincularPromocaoAoProduto(dtoRequest);

                return dtoResponse;
            }
            catch (Exception e)
            {
                dtoResponse.AdicionarErro($"Ocorreu um erro ao vincular produto com promoção. Erro: {e.Message}");
                return dtoResponse;
            }
        }
    }
}
