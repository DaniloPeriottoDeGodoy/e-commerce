using AppService.DI;
using AppService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Tests.Carrinho
{
    [TestClass]
    public class CarrinhoTestClass
    {
        private readonly IServiceCollection service;

        public CarrinhoTestClass() =>
            service = ServiceCollectionContainer.Initializer();

        [TestMethod]
        public void CalcularValorTotalCarrinhoTest()
        {
            try
            {
                using (var provider = service.BuildServiceProvider())
                {
                    var t = provider.GetService<IProdutoApplicationService>();
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
