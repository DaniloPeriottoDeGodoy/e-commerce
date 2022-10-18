using Dominio.DTO.Carrinho.ObterValorCarrinho;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Api.Tests.Carrinho
{
	[Binding]
	public class CarrinhoSteps
	{
		public HttpClient HttpClient { get; set; }

		[BeforeScenario]
		public void Setup()
		{
			HttpClient = new HttpClient();
		}

		[Given(@"carrinho está vazio")]
		public async Task GivenCarrinhoEstaVazio()
		{
			await HttpClient.PostAsync($"http://localhost:5000/api/Carrinho/LimparCarrinho", null);
		}

		[Given(@"produto (.*) possui promoção (.*)")]
		public async Task GivenProdutoPossuiPromocao(int idDoProduto, int idDaPromocao)
		{
			await HttpClient.PutAsync($"http://localhost:5000/api/Produtos/{idDoProduto}/Promocao/{idDaPromocao}", null);
		}

		[When(@"adicionar (.*) do produto (.*) no carrinho")]
		public async Task WhenAdicionarProdutoNoCarrinho(int quantidade, int idDoProduto)
		{
			object data = new { quantidade, idDoProduto };

			StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

			await HttpClient.PostAsync($"http://localhost:5000/api/Carrinho/Item", stringContent);
		}

		[Then(@"o valor do carrinho deve ser (.*)")]
		public async Task ThenOValorDoCarrinhoDeveSer(decimal valor)
		{
			var response = await HttpClient.GetAsync($"http://localhost:5000/api/Carrinho/Total");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
				var content = await response.Content.ReadAsStringAsync();
				var dtoResponse = JsonConvert.DeserializeObject<DtoObterValorCarrinhoResponse>(content);				

				Assert.AreEqual(valor, dtoResponse.ValorTotal);
			}			
		}
	}
}
