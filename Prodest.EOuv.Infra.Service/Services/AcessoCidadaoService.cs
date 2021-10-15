﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo;
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

        public AcessoCidadaoService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:AcessoCidadao");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiAcessoCidadao");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
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