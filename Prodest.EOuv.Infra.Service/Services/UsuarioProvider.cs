using AutoMapper;
using Prodest.Cache.Extensions.Caching.Hierarchical;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.Service
{
    public class UsuarioProvider : IUsuarioProvider
    {
        private readonly IMapper _mapper;
        private readonly IHierarchicalCache _hierarchicalCache;
        private readonly IAcessoCidadaoService _acessoCidadaoService;
        private readonly IUsuarioRepository _usuarioRepository;

        protected IUsuarioLogadoModel Usuario { get; set; }

        public IEnumerable<Claim> Claims { get; private set; }

        public UsuarioProvider(
            IHierarchicalCache hierarchicalCache,
            IAcessoCidadaoService acessoCidadaoService,
            IMapper mapper,
            IUsuarioRepository usuarioRepository
        )
        {
            _hierarchicalCache = hierarchicalCache;
            _acessoCidadaoService = acessoCidadaoService;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public IUsuarioLogadoModel GetCurrent()
        {
            return Usuario;
        }

        public async Task SetCurrent(ClaimsPrincipal user)
        {
            Claim claimSubNovo = user.FindFirst("subNovo");
            if (claimSubNovo != null)
            {
                var idUsuarioLogado = new Guid(claimSubNovo.Value);

                UsuarioLogadoModel cidadao = await FillCurrentUserAsync(idUsuarioLogado);
                cidadao.Login = user.FindFirst("cpf").Value;
                await PreencherUsuarioEouv(cidadao);
                Usuario = cidadao;
            }
        }

        private async Task<UsuarioLogadoModel> FillCurrentUserAsync(Guid idUsuarioLogado)
        {
            UsuarioLogadoModel cidadao = (UsuarioLogadoModel)await ObterCidadaoPorId(idUsuarioLogado);
            return cidadao;
        }

        public async Task<IUsuarioLogadoModel> ObterCidadaoPorId(Guid idCidadao)
        {
            UsuarioLogadoModel cidadao = await _hierarchicalCache.GetOrCreateAsync(
                $"cidadao-{idCidadao}",
                TimeSpan.FromMinutes(30),
                //timespan.fromminutes(30),
                async () =>
                {
                    UsuarioLogadoModel cidadao = await _acessoCidadaoService.GetUsuarioAsync(idCidadao);
                    await PreencherUsuarioAsync(cidadao);

                    return cidadao;
                }
            );
            return cidadao;
        }

        private async Task PreencherUsuarioAsync(UsuarioLogadoModel cidadao)
        {
            if (cidadao != null)
            {
                await PreencherPapeisByCidadao(cidadao);

                await PreencherPerfisPapeisByCidadao(cidadao);
            }
        }

        private async Task PreencherPapeisByCidadao(UsuarioLogadoModel cidadao)
        {
            if (cidadao == null)
                return;

            ICollection<PapelLogadoModel> listaPapelLotacao = await montaPapelLogadoModelAsync(cidadao.IdExterno.Value);

            if (!(listaPapelLotacao?.Count > 0))
            {
                cidadao.Papeis = new List<PapelLogadoModel>();
                return;
            }

            List<PapelLogadoModel> papeisComLocalizacao = listaPapelLotacao
                .Where(x => !String.IsNullOrEmpty(x.LotacaoGuid))
                .OrderBy(p => p.Nome)
                .ToList();

            papeisComLocalizacao.ToList()
                .ForEach(p => p.Servidor = cidadao);

            papeisComLocalizacao = papeisComLocalizacao ?? new List<PapelLogadoModel>();

            cidadao.Papeis = papeisComLocalizacao;
        }

        private async Task PreencherPerfisPapeisByCidadao(UsuarioLogadoModel cidadao)
        {
            if (cidadao == null)
                return;

            ICollection<(ICollection<PerfilLogadoModel> perfis, Guid idPapel)> perfisPorPapel = await _acessoCidadaoService.SearchPerfisPorPapelByUsuarioAsync(cidadao.IdExterno.Value);

            if (perfisPorPapel?.Count > 0)
            {
                foreach (PapelLogadoModel papeisCidadao in cidadao.Papeis)
                {
                    ICollection<PerfilLogadoModel> perfis =
                        perfisPorPapel.SingleOrDefault(ppp => ppp.idPapel == papeisCidadao.IdExterno)
                        .perfis;

                    perfis = perfis ?? new List<PerfilLogadoModel>();

                    papeisCidadao.Perfis = perfis;
                }
            }
        }

        private async Task<ICollection<PapelLogadoModel>> montaPapelLogadoModelAsync(Guid id)
        {
            List<PapelLogado> papeis = await _acessoCidadaoService.GetPapeisPorCidadaoAsync(id);

            List<PapelLogadoModel> papeisModel = null;
            if (papeis != null)
            {
                papeis = papeis
                    .Where(p => !string.IsNullOrWhiteSpace(p.LotacaoGuid))
                    .ToList();

                papeisModel = _mapper.Map<List<PapelLogadoModel>>(papeis);

                papeisModel = papeisModel?
                    //.OrderBy(p => p.Localizacao == null)   //traz os servidores sempre antes
                    //.ThenBy(p => p.Nome)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }

            return papeisModel;
        }

        private async Task PreencherUsuarioEouv(UsuarioLogadoModel cidadao)
        {
            var usuarioEouv = await _usuarioRepository.BuscarUsuarioPorLogin(cidadao.Login);

            cidadao.IdUsuarioEouv = usuarioEouv.IdUsuario;
            cidadao.IdOrgaoEouv = usuarioEouv.IdOrgao;
            cidadao.IdPerfilEouv = usuarioEouv.IdPerfil;
        }
    }
}