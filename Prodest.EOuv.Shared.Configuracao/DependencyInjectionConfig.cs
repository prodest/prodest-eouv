using Microsoft.Extensions.DependencyInjection;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.BLL;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Infra.DAL;

namespace Prodest.EOuv.Shared.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDespachoWorkService, DespachoWorkService>();

            services.AddScoped<IDespachoBLL, DespachoBLL>();

            services.AddScoped<IDespachoRepository, DespachoRepository>();
        }
    }
}