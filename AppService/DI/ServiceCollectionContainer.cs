using AppService.Interfaces;
using AppService.Services;
using Dominio.Interfaces;
using Dominio.Services;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppService.DI
{
    public static class ServiceCollectionContainer
    {
        private static IServiceCollection _services;

        public static IServiceCollection Initializer(IServiceCollection services = null)
        {
            _services = services;

            if (_services == null)
                _services = new ServiceCollection();
            
            _services.AddTransient<IProdutoRepository, ProdutoRepository>();
            _services.AddScoped(typeof(ProdutoService));

            _services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
            _services.AddScoped(typeof(CarrinhoService));

            _services.AddTransient<IPromocaoRepository, PromocaoRepository>();
            _services.AddScoped(typeof(PromocaoService));

            _services.AddTransient<ICarrinhoApplicationService, CarrinhoApplicationService>();
            _services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();

            return _services;
        }
    }
}
