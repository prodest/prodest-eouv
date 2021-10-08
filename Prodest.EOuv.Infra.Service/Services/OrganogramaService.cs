using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils;

namespace Prodest.EOuv.Infra.Service
{
    public class OrganogramaService : IOrganogramaService
    {
        private readonly string _baseUrl;
        private readonly int _cacheExpirationHours;
        private readonly IMemoryCache _memoryCache;
        private readonly IApiContext _apiContext;

        public OrganogramaService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:Organograma");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiOrganograma");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
        }

        // ======================
        // public methods
        // ======================

        public async Task<UnidadeModel> GetUnidade(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetUnidade)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<UnidadeModel>($"{_baseUrl}/unidades/{id}");
            });
        }

        public async Task<OrganizacaoModel> GetOrganizacao(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetOrganizacao)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<OrganizacaoModel>($"{_baseUrl}/organizacoes/{id}");
            });
        }

        public async Task<OrganizacaoModel[]> GetOrganizacoesFilhas(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetOrganizacoesFilhas)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<OrganizacaoModel[]>($"{_baseUrl}/organizacoes/{id}/filhas");
            });
        }

        public async Task<UnidadeModel[]> GetUnidadesOrganizacao(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetUnidadesOrganizacao)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<UnidadeModel[]>($"{_baseUrl}/unidades/organizacao/{id}");
            });
        }

        // ======================
        // private methods
        // ======================

        private async Task<T> GetRequest<T>(string url) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.GetRequest<T>(url, Enums.AuthenticationType.Application);

            if (!isSuccess)
            {
                var ex = new OrganogramaApiException(errorMessage);
                //ErrorLog.Log(ex);
                throw ex;
            }

            return data;
        }
    }
}
