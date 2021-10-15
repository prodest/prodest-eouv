using Microsoft.Extensions.DependencyInjection;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.BLL;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Infra.DAL;
using Prodest.EOuv.Infra;
using Prodest.EOuv.Infra.Service;

namespace Prodest.EOuv.Shared.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IApiContext, ApiContext>();
            services.AddScoped<IEDocsBLL, EDocsBLL>();
            services.AddScoped<IAcessoCidadaoService, AcessoCidadaoService>();
            services.AddScoped<IOrganogramaService, OrganogramaService>();
            services.AddScoped<IEDocsService, EDocsService>();
            services.AddScoped<IAcessoCidadaoBLL, AcessoCidadaoBLL>();
            services.AddScoped<IPdfApiBLL, PdfApiBLL>();
            services.AddScoped<IPdfApiService, PdfApiService>();
            services.AddScoped<IHtmlApiBLL, HtmlApiBLL>();
            services.AddScoped<IHtmlApiService, HtmlApiService>();

            services.AddScoped<IDespachoWorkService, DespachoWorkService>();
            services.AddScoped<IManifestacaoWorkService, ManifestacaoWorkService>();

            services.AddScoped<IDespachoBLL, DespachoBLL>();
            services.AddScoped<IManifestacaoBLL, ManifestacaoBLL>();

            services.AddScoped<IDespachoRepository, DespachoRepository>();
            services.AddScoped<IManifestacaoRepository, ManifestacaoRepository>();
        }
    }
}