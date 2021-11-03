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
       //private readonly IVerificacaoRepository Verificacao;
       // private readonly ISistemaRepository Sistemas;

       // private readonly ICidadaoRepository CidadaoRepository;
       // private readonly ILocalizacaoRepository LocalizacaoRepository;
       // private readonly IPapelRepository PapelRepository;
       // private readonly IConjuntoRepository ConjuntoRepository;
       // private readonly IGrupoRepository GrupoRepository;
       // private readonly IOrganizacaoRepository OrganizacaoRepository;
       // private readonly IOrganizacaoPatriarcaRepository OrganizacaoPatriarcaRepository;

        protected IUsuarioLogadoModel Usuario { get; set; }

        public IEnumerable<Claim> Claims { get; private set; }

        public UsuarioProvider(
            IHierarchicalCache hierarchicalCache,
            IAcessoCidadaoService acessoCidadaoService,
            IMapper mapper
        //ISistemaRepository sistemas, IVerificacaoRepository verificacao,
        //IOrganizacaoPatriarcaRepository organizacaoPatriarcaRepository,
        //IConjuntoRepository conjuntoRepository, ICidadaoRepository cidadaoRepository,
        //ILocalizacaoRepository localizacaoRepository,
        //IPapelRepository papelRepository, IGrupoRepository grupoRepository,
        //IOrganizacaoRepository organizacaoRepository
        )
        {
            _hierarchicalCache = hierarchicalCache;
            AcessoCidadaoService = acessoCidadaoService;
            _mapper = mapper;
            //Sistemas = sistemas;
            //Verificacao = verificacao;
            //ConjuntoRepository = conjuntoRepository;
            //CidadaoRepository = cidadaoRepository;
            //LocalizacaoRepository = localizacaoRepository;
            //PapelRepository = papelRepository;
            //GrupoRepository = grupoRepository;
            //OrganizacaoRepository = organizacaoRepository;
            //OrganizacaoPatriarcaRepository = organizacaoPatriarcaRepository;
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
                //bool verificado = await Verificacao.UsuarioVerificacaoAceita(idUsuarioLogado);

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

            //UsuarioLogadoModel cidadao =
            //           await AcessoCidadaoService.GetUsuarioAsync(idCidadao);
            //await PreencherUsuarioAsync(cidadao);


            //return cidadao;
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
                ///await AcessoCidadaoService.GetPapeisPorCidadaoAsync(cidadao.IdExterno.Value);

            if (!(listaPapelLotacao?.Count > 0))
            {
                cidadao.Papeis = new List<PapelLogadoModel>();
                return;
            }

            //foreach ((PapelLogadoModel papel, string lotacao) papelELotacao in listaPapelLotacao)
            //    if (!string.IsNullOrWhiteSpace(papelELotacao.lotacao))
            //        papelELotacao.papel.Localizacao =
            //            await LocalizacaoRepository.SearchAsync(new Guid(papelELotacao.lotacao));

            List<PapelLogadoModel> papeisComLocalizacao = listaPapelLotacao
                .Where(x => !String.IsNullOrEmpty(x.LotacaoGuid))
                //.Select(x => x.papel)
                .OrderBy(p => p.Nome)
                .ToList();

            //ICollection<PapelLogadoModel> papeisValidos =
            //    await RemoverAgentesPatriarcasDesabilitados(papeisComLocalizacao);

            //papeisValidos.ToList()
            //    .ForEach(p => p.Servidor = cidadao);

            papeisComLocalizacao.ToList()
                .ForEach(p => p.Servidor = cidadao);

            //papeisValidos = papeisValidos ?? new List<PapelModel>();
            papeisComLocalizacao = papeisComLocalizacao ?? new List<PapelLogadoModel>();

            //cidadao.Papeis = papeisValidos;
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

                //if (papeisModel != null && papeisModel.Any())
                //{
                //    foreach (PapelLogadoModel papelModel in papeisModel)
                //    {
                //        //papelModel.Servidor.Papeis = papeisModel;

                //        var papel = papeis
                //            .SingleOrDefault(p => !string.IsNullOrWhiteSpace(p.Guid)
                //                && papelModel.IdExterno.HasValue
                //                && p.Guid.Equals(papelModel.IdExterno.Value.ToString()));

                //        //if (papel != null && !string.IsNullOrWhiteSpace(papel.LotacaoGuid))
                //        //    papelModel.Localizacao = await Localizacoes.SearchAsync(new Guid(papel.LotacaoGuid));
                //    }
                //}

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

        //public async Task<CidadaoModel> ObterCidadaoPorCpfOuAdicionar(string cpf)
        //{
        //    if (string.IsNullOrEmpty(cpf))
        //        throw new MisuseException(StatusCodeMisuse.Required, nameof(cpf));

        //    CidadaoModel cidadaoIncompleto = await CidadaoRepository.SearchByCpfOrAddAsync(cpf);

        //    CidadaoModel cidadaoCompleto = await ObterCidadaoPorId(cidadaoIncompleto.IdExterno.Value);

        //    return cidadaoCompleto;
        //}

        //public async Task<ICollection<CidadaoModel>> ObterCidadaosPorPerfil(Guid idPerfil)
        //{
        //    ICollection<CidadaoModel> listaCidadaoIncompleto =
        //        await CidadaoRepository.SearchByPerfil(idPerfil);

        //    ICollection<CidadaoModel> listaCidadaosCompletos = new List<CidadaoModel>();
        //    foreach (var cidadaoIncompleto in listaCidadaoIncompleto)
        //        listaCidadaosCompletos.Add(await ObterCidadaoPorId(cidadaoIncompleto.IdExterno.Value));

        //    return listaCidadaosCompletos;
        //}

        //public async Task<ICollection<GrupoModel>> ObterGruposByServidorAsync(Guid idCidadao)
        //{
        //    ICollection<GrupoModel> grupos =
        //        await GrupoRepository.SearchByServidorAsync(idCidadao);

        //    if (!(grupos.Count > 0))
        //        return new List<GrupoModel>();

        //    foreach (var grupo in grupos)
        //        if (grupo != null && grupo.IdConjuntoPai.HasValue && !grupo.IdConjuntoPai.Value.Equals(Guid.Empty))
        //            grupo.ConjuntoPai = await ConjuntoRepository.SearchAsync(grupo.IdConjuntoPai.Value);

        //    grupos = grupos?
        //        .OrderBy(g => g.Nome)
        //        .ToList();

        //    ICollection<GrupoModel> gruposValidos =
        //        await RemoverAgentesPatriarcasDesabilitados(grupos);

        //    gruposValidos = gruposValidos ?? new List<GrupoModel>();

        //    return gruposValidos;
        //}

        //public async Task<ICollection<OrganizacaoModel>> ObterPatriarcasHabilitadosAsync()
        //{
        //    List<OrganizacaoModel> retorno = await HierarchicalCache.GetOrCreateAsync(
        //        "ListaPatriarcasHabilitados",
        //        new TimeSpan(2, 0, 0),
        //        async () =>
        //        {
        //            ICollection<OrganizacaoPatriarcaModel> patriarcas =
        //                await OrganizacaoPatriarcaRepository.ListAsync();

        //            List<OrganizacaoModel> patriarcasHabilitados = new List<OrganizacaoModel>();

        //            foreach (var patriarca in patriarcas)
        //            {
        //                OrganizacaoModel organizacao =
        //                    await OrganizacaoRepository.SearchAsync(patriarca.Organizacao.Value);

        //                if (organizacao != null && organizacao.IsOrganizacao)
        //                    patriarcasHabilitados.Add(organizacao);
        //            }

        //            return patriarcasHabilitados.Any() ? patriarcasHabilitados : null;

        //        }
        //    );

        //    return retorno;
        //}

        //public async Task<ICollection<T>> RemoverAgentesPatriarcasDesabilitados<T>(ICollection<T> agentes) where T : AgenteModel
        //{
        //    List<T> agentesPatriarcasAtivos = new List<T>();

        //    if (agentes == null || agentes.Count == 0)
        //        return agentesPatriarcasAtivos;

        //    ICollection<OrganizacaoModel> patriarcasAtivos =
        //        await ObterPatriarcasHabilitadosAsync();

        //    agentesPatriarcasAtivos = agentes.Where(
        //        x => patriarcasAtivos.Select(x => x.IdExterno).Contains(x.OrganizacaoPatriarca.IdExterno)
        //    ).ToList();

        //    return agentesPatriarcasAtivos;
        //}

        //#region Privados



        //private async Task PreencherCidadaoEmails(CidadaoModel cidadao)
        //{
        //    EmailsCidadaoModel emailsCidadao =
        //        await CidadaoRepository.SearchCidadaoEmails(cidadao.IdExterno.Value);

        //    if (emailsCidadao != null && emailsCidadao.corporativo != null)
        //        cidadao.EmailCorporativo = emailsCidadao.corporativo;
        //}

        //private async Task PreencherConjuntoGestorByCidadao(CidadaoModel cidadao)
        //{
        //    if (cidadao == null)
        //        return;

        //    ICollection<Guid> idsConjuntos =
        //        await ConjuntoRepository.SearchConjuntosGestorByCidadaoAsync(cidadao.IdExterno.Value);

        //    idsConjuntos = idsConjuntos ?? new List<Guid>();

        //    ICollection<ConjuntoModel> conjuntos = new List<ConjuntoModel>();

        //    foreach (var idConjunto in idsConjuntos)
        //    {
        //        ConjuntoModel conjunto = await ConjuntoRepository.SearchAsync(idConjunto);

        //        conjuntos.Add(conjunto);
        //    }

        //    conjuntos = await RemoverAgentesPatriarcasDesabilitados(conjuntos);

        //    conjuntos = conjuntos ?? new List<ConjuntoModel>();

        //    cidadao.ConjuntosGestor = conjuntos;

        //    await PreencherConjuntoGestorPapelByCidadao(cidadao);
        //}

        //private async Task PreencherConjuntoGestorPapelByCidadao(CidadaoModel cidadao)
        //{
        //    if (cidadao == null)
        //        return;

        //    if (cidadao.ConjuntosGestor == null)
        //        return;

        //    if (cidadao.ConjuntosGestor.Count == 0)
        //    {
        //        cidadao.ConjuntoGestorPapel = new List<KeyValuePair<Guid, Guid>>();
        //        return;
        //    }

        //    foreach (ConjuntoModel conjuntoGestor in cidadao.ConjuntosGestor)
        //    {
        //        if (conjuntoGestor != null && conjuntoGestor.IdExterno.HasValue)
        //        {
        //            Guid? idPapelGestor =
        //                await PapelRepository.SearchGestorByConjuntoAsync(conjuntoGestor.IdExterno.Value);

        //            if (idPapelGestor != null && idPapelGestor != Guid.Empty)
        //            {
        //                if (cidadao.Papeis.Any(p => p.IdExterno.Value.Equals(idPapelGestor.Value)))
        //                {
        //                    KeyValuePair<Guid, Guid> conjuntoGestorPapel =
        //                        new KeyValuePair<Guid, Guid>(conjuntoGestor.IdExterno.Value, idPapelGestor.Value);

        //                    if (cidadao.ConjuntoGestorPapel == null)
        //                        cidadao.ConjuntoGestorPapel = new List<KeyValuePair<Guid, Guid>>() { conjuntoGestorPapel };
        //                    else
        //                        cidadao.ConjuntoGestorPapel.Add(conjuntoGestorPapel);
        //                }
        //            }
        //        }
        //    }

        //    cidadao.ConjuntoGestorPapel =
        //        cidadao.ConjuntoGestorPapel
        //        ?? new List<KeyValuePair<Guid, Guid>>();
        //}

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

                    //foreach (PerfilLogadoModel perfil in perfis)
                    //{
                    //    perfil.IdsLocalizacoes = perfil.IdsLocalizacoes ?? new List<Guid>();
                    //    perfil.Localizacoes = perfil.Localizacoes ?? new List<LocalizacaoModel>();

                    //    foreach (Guid idLocalizacao in perfil.IdsLocalizacoes)
                    //        perfil.Localizacoes.Add(await LocalizacaoRepository.SearchAsync(idLocalizacao));

                    //}

                    papeisCidadao.Perfis = perfis;
                }
            }
        }



        //private async Task PreencherGruposPorServidor(CidadaoModel cidadao)
        //{
        //    if (cidadao == null)
        //        return;

        //    ICollection<GrupoModel> gruposValidos =
        //        await ObterGruposByServidorAsync(cidadao.IdExterno.Value);

        //    cidadao.Grupos = gruposValidos;
        //}

    }
}