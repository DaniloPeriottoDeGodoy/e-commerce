using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		[HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
		public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
		{
		}
	}
}
