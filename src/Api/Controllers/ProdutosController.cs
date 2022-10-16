using AppService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {        
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService)
        {            
            _produtoApplicationService = produtoApplicationService;
        }

        [HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
        public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
        {
            try
            {
                _produtoApplicationService.VincularPromocaoAoProduto(idDaPromocao, idDoProduto);                
                
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
