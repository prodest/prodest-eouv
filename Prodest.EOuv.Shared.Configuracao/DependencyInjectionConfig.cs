using Microsoft.Extensions.DependencyInjection;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.BLL;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Infra.DAL;
using Prodest.EOuv.Infra;
using Prodest.EOuv.Infra.Service;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;

namespace Prodest.EOuv.Shared.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IApiContext, ApiContext>();
            services.AddScoped<IAcessoCidadaoService, AcessoCidadaoService>();
            services.AddScoped<IOrganogramaService, OrganogramaService>();
            services.AddScoped<IEDocsService, EDocsService>();
            services.AddScoped<IPdfApiService, PdfApiService>();
            services.AddScoped<IHtmlApiService, HtmlApiService>();

            services.AddScoped<IDespachoWorkService, DespachoWorkService>();
            services.AddScoped<IManifestacaoWorkService, ManifestacaoWorkService>();
            services.AddScoped<IRespostaWorkService, RespostaWorkService>();

            services.AddScoped<IDespachoBLL, DespachoBLL>();
            services.AddScoped<IManifestacaoBLL, ManifestacaoBLL>();
            services.AddScoped<IRespostaBLL, RespostaBLL>();
            services.AddScoped<IAgenteBLL, AgenteBLL>();

            services.AddScoped<IDespachoRepository, DespachoRepository>();
            services.AddScoped<IManifestacaoRepository, ManifestacaoRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddScoped<IAgenteRepository, AgenteRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();

            services.AddScoped<IUsuarioProvider, UsuarioProvider>();
            services.AddScoped<IPermissaoService, PermissaoService>();
        }
    }
}