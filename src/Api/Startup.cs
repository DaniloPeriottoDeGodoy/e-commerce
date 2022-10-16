using AppService.Interfaces;
using AppService.Services;
using Dominio.Interfaces;
using Dominio.Services;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "teste", Version = "v1" });
			});

			services.AddTransient<IProdutoRepository, ProdutoRepository>();
			services.AddScoped(typeof(ProdutoService));
			
			services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
			services.AddScoped(typeof(CarrinhoService));

			services.AddTransient<IPromocaoRepository, PromocaoRepository>();
			services.AddScoped(typeof(PromocaoService));

			services.AddTransient<ICarrinhoApplicationService, CarrinhoApplicationService>();
			services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
		}
	}
}
