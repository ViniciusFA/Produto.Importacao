using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Produto.Importacao.Data.Repositories;
using Produto.Importacao.Domain.Interfaces.Queries;
using Produto.Importacao.Domain.Interfaces.Repositories;
using Produto.Importacao.Domain.Queries;
using System;

namespace Produto.Importacao.IoC
{
    public static class Register
    {
        public static void RegisterIoC(IConfiguration configuration, IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Injeção de Dependencia
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Queries
            services.AddScoped<IQueryGetImports, QueryGetImports>();

            //Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
