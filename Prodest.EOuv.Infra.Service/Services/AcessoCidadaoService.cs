using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils;

namespace Prodest.EOuv.Infra.Service
{
    public class AcessoCidadaoService : IAcessoCidadaoService
    {
        private readonly string _baseUrl;
        private readonly int _cacheExpirationHours;
        private readonly IMemoryCache _memoryCache;
        private readonly IApiContext _apiContext;
        private readonly IOrganogramaService _organogramaService;

        public AcessoCidadaoService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext,
            IOrganogramaService organogramaService
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:AcessoCidadao");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiAcessoCidadao");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
            _organogramaService = organogramaService;
        }

        // ======================
        // public methods
        // ======================

        public async Task<AgentePublicoPapelModel[]> GetAgentePublicoPapeis(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetAgentePublicoPapeis)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<AgentePublicoPapelModel[]>($"{_baseUrl}/agentepublico/{id}/papeis");
            });
        }

        public async Task<AgentePublicoPapelModel> GetPapel(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetPapel)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<AgentePublicoPapelModel>($"{_baseUrl}/papel/{id}");
            });
        }

        public async Task<AgentePublicoModel> GetConjuntoGestor(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetConjuntoGestor)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<AgentePublicoModel>($"{_baseUrl}/conjunto/{id}/gestor");
            });
        }

        public async Task<ConjuntoGrupoModel[]> GetConjuntoGrupos(string id, string tipoFiltro)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetConjuntoGrupos)}::{id}::{tipoFiltro}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<ConjuntoGrupoModel[]>($"{_baseUrl}/conjunto/{id}/grupos?incluirFilhos=true&tipoFiltro={tipoFiltro}");
            });
        }

        public async Task<AgentePublicoModel[]> GetConjuntoAgentesPublicos(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetConjuntoAgentesPublicos)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<AgentePublicoModel[]>($"{_baseUrl}/conjunto/{id}/agentesPublicos");
            });
        }

        public async Task<PermissaoUsuarioModel> GetPermissaoUsuario(string id)
        {
            return await GetRequest<PermissaoUsuarioModel>($"{_baseUrl}/restrito/usuario/{id}/permissoes");
        }

        public async Task<AgentePublicoPapelModel[]> GetAgentePublico(string id, string busca)
        {
            return await GetRequest<AgentePublicoPapelModel[]>($"{_baseUrl}/conjunto/{id}/papeis/{busca}");
        }

        public async Task<UnidadeModel[]> GetUnidadesPerfilAdministrador(Guid id)
        {
            var response = await GetPermissaoUsuario(id.ToString());
            var ret = new List<UnidadeModel>();

            foreach (var papel in response.Papeis)
            {
                var perfilAdministrador = papel.Perfis.First(x => x.Nome.ToUpper() == "ADMINISTRADOR");

                foreach (var orgao in perfilAdministrador.Orgaos)
                {
                    ret.Add(await _organogramaService.GetUnidade(orgao.Guid));
                }
            }

            return ret.ToArray();
        }

        // ======================
        // private methods
        // ======================

        private async Task<T> GetRequest<T>(string url) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.GetRequest<T>(url, Enums.AuthenticationType.Application);

            if (!isSuccess)
            {
                var ex = new AcessoCidadaoApiException(errorMessage);
                //ErrorLog.Log(ex);
                throw ex;
            }

            return data;
        }
    }
}