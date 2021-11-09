using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils;

namespace Prodest.EOuv.Infra.Service
{
    public class AcessoCidadaoService : IAcessoCidadaoService
    {
        private readonly string _baseUrl;
        private readonly string _baseUrlRestrito;
        private readonly int _cacheExpirationHours;
        private readonly IMemoryCache _memoryCache;
        private readonly IApiContext _apiContext;
        private readonly IOrganogramaService _organogramaService;
        private readonly IMapper _mapper;

        public AcessoCidadaoService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext,
            IOrganogramaService organogramaService,
            IMapper mapper
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:AcessoCidadao");
            _baseUrlRestrito = configuration.GetValue<string>("ApiUrls:AcessoCidadaoRestrito");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiAcessoCidadao");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
            _organogramaService = organogramaService;
            _mapper = mapper;
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

        public async Task<AgentePublicoPapelModel> GetGrupo(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetAgentePublicoPapeis)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<AgentePublicoPapelModel>($"{_baseUrl}/grupo/{id}");
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

        public async Task<List<AgentePublicoPapelModel>> GetAgentePublico(string id, string busca)
        {
            return await GetRequest<List<AgentePublicoPapelModel>>($"{_baseUrl}/conjunto/{id}/papeis/{busca}");
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

        public async Task<List<PapelLogado>> GetPapeisPorCidadaoAsync(Guid idCidadao)
        {
            List<PapelLogadoModel> retorno;

            string url = $"{_baseUrl}/agentepublico/{idCidadao.ToString()}/papeis";

            List<PapelLogado> papeis = await GetRequest<List<PapelLogado>>(url);

            return papeis;
        }

        public async Task<UsuarioLogadoModel> GetUsuarioAsync(Guid id)
        {
            UsuarioLogadoModel retorno;
            string url = $"{_baseUrlRestrito}/cidadao/{id.ToString()}";

            UsuarioLogado usuario = await GetRequest<UsuarioLogado>(url);

            retorno = _mapper.Map<UsuarioLogadoModel>(usuario);

            return retorno;
        }

        public async Task<ICollection<(ICollection<PerfilLogadoModel> perfis, Guid papel)>> SearchPerfisPorPapelByUsuarioAsync(Guid idCidadao)
        {
            ICollection<(ICollection<PerfilLogadoModel> perfis, Guid papel)> perfisPorPapel =
                new List<(ICollection<PerfilLogadoModel> perfis, Guid papel)>();

            string url = $"{_baseUrlRestrito}/usuario/{idCidadao.ToString()}/permissoes";

            Permissao permissaoAC = await GetRequest<Permissao>(url);

            if (permissaoAC?.Papeis?.Count > 0)
            {
                foreach (PapelPermissao papelPermissaoAC in permissaoAC.Papeis)
                {
                    if (!string.IsNullOrWhiteSpace(papelPermissaoAC.LotacaoGuid))
                    {
                        ICollection<PerfilLogadoModel> perfis = null;

                        if (papelPermissaoAC?.Perfis?.Count > 0)
                        {
                            perfis = new List<PerfilLogadoModel>();

                            foreach (var perfilAC in papelPermissaoAC.Perfis)
                            {
                                //Obterndo a Localização do Perfil do Papel
                                ICollection<Guid> localizacoesPerfil = new List<Guid>();

                                if (perfilAC?.Orgaos?.Count > 0)
                                {
                                    List<Guid> orgaos = perfilAC.Orgaos
                                        .GroupBy(o => o.Guid)
                                        .Select(o => new Guid(o.Key))
                                        .ToList();

                                    if (orgaos?.Count > 0)
                                        localizacoesPerfil = orgaos;
                                }

                                //Obtendo os recursos do Perfil
                                ICollection<RecursoModel> recursos = null;
                                if (perfilAC.Recursos != null && perfilAC.Recursos.Any())
                                {
                                    recursos = new List<RecursoModel>();

                                    foreach (RecursoModel recurso in perfilAC.Recursos)
                                    {
                                        if (recurso != null)
                                        {
                                            ICollection<AcaoModel> acoes = null;

                                            if (recurso.Acoes != null && recurso.Acoes.Any())
                                            {
                                                acoes = recurso.Acoes
                                                    .Select(a => new AcaoModel
                                                    {
                                                        IdentificadorExterno = new Guid(a.Guid),
                                                        Nome = a.Nome,
                                                        Descricao = a.Descricao
                                                    })
                                                    .ToList();
                                            }

                                            recursos.Add(new RecursoModel
                                            {
                                                IdentificadorExterno = new Guid(recurso.Guid),
                                                Nome = recurso.Nome,
                                                Descricao = recurso.Descricao,
                                                Acoes = acoes.ToArray()
                                            });
                                        }
                                    }
                                }

                                PerfilLogadoModel perfil = new PerfilLogadoModel
                                {
                                    IdExterno = new Guid(perfilAC.Guid),
                                    Nome = perfilAC.Nome,
                                    Descricao = perfilAC.Descricao,
                                    //IdsLocalizacoes = localizacoesPerfil,
                                    Recursos = recursos?.ToArray()
                                };

                                perfis.Add(perfil);
                            }
                        }

                        perfisPorPapel.Add((perfis, new Guid(papelPermissaoAC.Guid)));
                    }
                }
            }

            return perfisPorPapel;
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