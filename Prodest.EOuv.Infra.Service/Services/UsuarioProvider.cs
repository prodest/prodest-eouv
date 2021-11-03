using AutoMapper;
using Prodest.Cache.Extensions.Caching.Hierarchical;
using Prodest.EOuv.Dominio.Modelo;
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
        private readonly IAcessoCidadaoService AcessoCidadaoService;

        protected IUsuarioLogadoModel Usuario { get; set; }

        public IEnumerable<Claim> Claims { get; private set; }

        public UsuarioProvider(
            IHierarchicalCache hierarchicalCache,
            IAcessoCidadaoService acessoCidadaoService,
            IMapper mapper
        )
        {
            _hierarchicalCache = hierarchicalCache;
            AcessoCidadaoService = acessoCidadaoService;
            _mapper = mapper;
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
                Usuario = cidadao;
            }
        }

        public async Task<IUsuarioLogadoModel> ObterCidadaoPorId(Guid idCidadao)
        {
            UsuarioLogadoModel cidadao = await _hierarchicalCache.GetOrCreateAsync(
                $"cidadao-{idCidadao}",
                TimeSpan.FromMinutes(30),
                //timespan.fromminutes(30),
                async () =>
                {
                    UsuarioLogadoModel cidadao =
                       await AcessoCidadaoService.GetUsuarioAsync(idCidadao);
                    await PreencherUsuarioAsync(cidadao);

                    return cidadao;
                }
            );
            return cidadao;

        }

        private async Task<UsuarioLogadoModel> FillCurrentUserAsync(Guid idUsuarioLogado)
        {
            UsuarioLogadoModel cidadao = (UsuarioLogadoModel) await ObterCidadaoPorId(idUsuarioLogado);
            return cidadao;
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

        private async Task<ICollection<PapelLogadoModel>> montaPapelLogadoModelAsync(Guid id )
        {
            List<PapelLogado> papeis = await AcessoCidadaoService.GetPapeisPorCidadaoAsync(id);

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

        private async Task PreencherUsuarioAsync(UsuarioLogadoModel cidadao)
        {
            if (cidadao != null)
            {
                await PreencherPapeisByCidadao(cidadao);

                //if (cidadao.IsServidor)
                //{
                    await PreencherPerfisPapeisByCidadao(cidadao);

                //    await PreencherGruposPorServidor(cidadao);

                //    await PreencherConjuntoGestorByCidadao(cidadao);
                //}

                //await PreencherCidadaoEmails(cidadao);
            }
        }

        private async Task PreencherPerfisPapeisByCidadao(UsuarioLogadoModel cidadao)
        {
            if (cidadao == null)
                return;

            ICollection<(ICollection<PerfilLogadoModel> perfis, Guid idPapel)> perfisPorPapel =
                await AcessoCidadaoService.SearchPerfisPorPapelByUsuarioAsync(cidadao.IdExterno.Value);

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
    }
}