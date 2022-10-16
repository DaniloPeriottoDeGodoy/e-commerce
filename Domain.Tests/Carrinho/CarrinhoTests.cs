using AppService.DI;
using AppService.Interfaces;
using Dominio.Models;
using Dominio.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests.Carrinho
{
    [TestClass]
    public class CarrinhoTestClass
    {
        private readonly IServiceCollection service;

        public CarrinhoTestClass() =>
            service = ServiceCollectionContainer.Initializer();

        // Cenário 1
        [TestMethod]
        public void AdicionarItemSemPromoçãoNoCarrinhoTest()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var carrinhoApp = provider.GetService<ICarrinhoApplicationService>();

                    // carrinho está vazio
                    carrinhoApp.LimparCarrinho();

                    // adicionar 1 do produto 1 no carrinho
                    carrinhoApp.AdicionarProdutoNoCarrinho(1, 1);

                    // o valor do carrinho deve ser
                    var total = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(total == 50);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Cenário 2
        [TestMethod]
        public void AdicionarItemComPromoçãoDoisPorUmNoCarrinhoTest()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var carrinhoApp = provider.GetService<ICarrinhoApplicationService>();
                    var produtoApp = provider.GetService<IProdutoApplicationService>();

                    // carrinho está vazio
                    carrinhoApp.LimparCarrinho();

                    // produto 2 possui promoção 1 (vincular)
                    produtoApp.VincularPromocaoAoProduto(1, 2);

                    // adicionar 2 do produto 2 no carrinho
                    carrinhoApp.AdicionarProdutoNoCarrinho(2, 2);

                    // o valor do carrinho deve ser 30
                    var total = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(total == 30);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Cenário 3
        [TestMethod]
        public void AdicionarItemComPromocaoTresPorDezNoCarrinho()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var carrinhoApp = provider.GetService<ICarrinhoApplicationService>();
                    var produtoApp = provider.GetService<IProdutoApplicationService>();

                    // carrinho está vazio
                    carrinhoApp.LimparCarrinho();

                    // produto 3 possui promoção 2 (vincular)
                    produtoApp.VincularPromocaoAoProduto(2, 3);

                    // Adicionar 3x (qtd 1 do produto 3 no carrinho)
                    for (int i = 0; i < 3; i++)
                    {
                        carrinhoApp.AdicionarProdutoNoCarrinho(3, 1);
                    }

                    // o valor do carrinho deve ser 10
                    var total = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(total == 10);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AgruparProdutoxQuantidade_DeveIdentificar1ProdutoComQuantidade3()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var carrinhoApp = provider.GetService<ICarrinhoApplicationService>();
                    var produtoApp = provider.GetService<IProdutoApplicationService>();

                    //PASSOS EXECUTADOS NO CENÁRIO 3..........
                    // carrinho está vazio
                    carrinhoApp.LimparCarrinho();

                    // produto 3 possui promoção 2 (vincular)
                    produtoApp.VincularPromocaoAoProduto(2, 3);

                    // Adicionar 3x (qtd 1 do produto 3 no carrinho)
                    for (int i = 0; i < 3; i++)
                        carrinhoApp.AdicionarProdutoNoCarrinho(3, 1);

                    // Antes de calcular o valor total do carrinho, é preciso identificar quantos itens tem de cada produto.
                    
                    var carrinhoService = provider.GetService<CarrinhoService>();

                    var carrinho = carrinhoService.ObterCarrinho();
                        
                    var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
                    if (carrinho.ListaProdutosCarrinho.Count > 0)
                    {                        
                        foreach (var item in carrinho.ListaProdutosCarrinho)
                        {
                            // Quando não tem nada adiciona o primeiro produto à lista
                            if (listaAgrupadaPorProdutoxQuantidade.Count == 0)
                            {
                                listaAgrupadaPorProdutoxQuantidade.Add(item);
                                continue;
                            }

                            var jaTemEsseProduto = listaAgrupadaPorProdutoxQuantidade.Exists(x => x.IdDoProduto == item.IdDoProduto);
                            if (jaTemEsseProduto)
                            {
                                listaAgrupadaPorProdutoxQuantidade.FirstOrDefault(x => x.IdDoProduto == item.IdDoProduto).Quantidade += item.Quantidade;
                            }
                        }
                    }

                    Assert.IsTrue(listaAgrupadaPorProdutoxQuantidade.Count == 1 && listaAgrupadaPorProdutoxQuantidade[0].Quantidade == 3);   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
