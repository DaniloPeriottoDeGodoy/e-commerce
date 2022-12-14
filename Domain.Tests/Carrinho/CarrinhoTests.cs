using AppService.DI;
using AppService.Interfaces;
using Dominio.DTO.Carrinho.AdicionarItem;
using Dominio.DTO.Produto;
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
                    DtoAdicionarItemRequest dtoRequest = new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 1,
                        Quantidade = 1
                    };

                    carrinhoApp.AdicionarProdutoNoCarrinho(dtoRequest);

                    // o valor do carrinho deve ser
                    var response = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(response.ValorTotal == 50);
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
                    produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(1, 2));

                    // adicionar 2 do produto 2 no carrinho
                    DtoAdicionarItemRequest dtoRequest = new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 2,
                        Quantidade = 2
                    };
                    carrinhoApp.AdicionarProdutoNoCarrinho(dtoRequest);

                    // o valor do carrinho deve ser 30
                    var response = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(response.ValorTotal == 30);
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
                    produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(2, 3));

                    // Adicionar 3x (qtd 1 do produto 3 no carrinho)
                    DtoAdicionarItemRequest dtoRequest = new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 3,
                        Quantidade = 1
                    };

                    for (int i = 0; i < 3; i++)
                    {
                        carrinhoApp.AdicionarProdutoNoCarrinho(dtoRequest);
                    }

                    // o valor do carrinho deve ser 10
                    var response = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(response.ValorTotal == 10);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Cenário 4
        [TestMethod]
        public void AdicionarVariosItensNoCarrinho()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var carrinhoApp = provider.GetService<ICarrinhoApplicationService>();
                    var produtoApp = provider.GetService<IProdutoApplicationService>();

                    // carrinho está vazio
                    carrinhoApp.LimparCarrinho();

                    // produto 2 possui promoção 1
                    produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(1, 2));

                    // produto 3 possui promoção 2                    
                    produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(2, 3));


                    // adicionar 1 do produto 1 no carrinho
                    carrinhoApp.AdicionarProdutoNoCarrinho(new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 1,
                        Quantidade = 1
                    });

                    // adicionar 3 do produto 2 no carrinho
                    carrinhoApp.AdicionarProdutoNoCarrinho(new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 2,
                        Quantidade = 3
                    });

                    // adicionar 4 do produto 3 no carrinho
                    carrinhoApp.AdicionarProdutoNoCarrinho(new DtoAdicionarItemRequest
                    {
                        IdDoProduto = 3,
                        Quantidade = 4
                    });

                    // o valor do carrinho deve ser 130
                    var response = carrinhoApp.ObterValorTotalCarrinho();

                    Assert.IsTrue(response.ValorTotal == 130);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

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
                    produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(2, 3));

                    // Adicionar 3x (qtd 1 do produto 3 no carrinho)                   
                    for (int i = 0; i < 3; i++)
                    {
                        carrinhoApp.AdicionarProdutoNoCarrinho(new DtoAdicionarItemRequest
                        {
                            IdDoProduto = 3,
                            Quantidade = 1
                        });
                    }

                    // Antes de calcular o valor total do carrinho, é preciso identificar quantos itens tem de cada produto.

                    var carrinhoService = provider.GetService<CarrinhoService>();

                    var carrinho = carrinhoService.ObterCarrinho();

                    var listaAgrupadaPorProdutoxQuantidade = new List<Item>();
                    if (carrinho.ListaItensCarrinho.Count > 0)
                    {
                        foreach (var item in carrinho.ListaItensCarrinho)
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

        [TestMethod]
        public void VincularProdutoComPromocaoQueNaoExiste_DeveIdentificarQueTemErroDeProdutoNaoEncontrado()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var produtoApp = provider.GetService<IProdutoApplicationService>();

                    var dto = produtoApp.VincularPromocaoAoProduto(new DtoVincularPromocaoAoProdutoRequest(2, 10));
                    Assert.IsTrue(dto.PossuiErros && dto.ListaErros[0].MensagemErro.Equals("Produto não encontrado."));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
