using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CarrinhoController : ControllerBase
	{
		private static readonly List<Produto> _produtos = new List<Produto>
		{
			new Produto { Id = 1, Nome = "PS5", Preco = 50 },
			new Produto { Id = 2, Nome = "TV do Edi 32 polegadas (Modelo 2002)", Preco = 30 },
			new Produto { Id = 3, Nome = "Sanfona do Buxin", Preco = 10 }
		};

		[HttpPost("Item")]
		public void AdicionarItem(Item item)
		{
		}

		[HttpPost("LimparCarrinho")]
		public void LimparCarrinho()
		{
		}

		[HttpGet("Total")]
		public decimal ObterTotalDoCarrinho()
		{
			return 0;
		}
	}

	public class Item
	{
		public int IdDoProduto { get; set; }
		public int Quantidade { get; set; }
	}

	public class Produto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
	}
}
