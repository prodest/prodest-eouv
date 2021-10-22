using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Infra.DAL;
using Prodest.EOuv.UI.Apresentacao;
using System;

namespace Prodest.EOuv.Shared.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<DespachoManifestacao, DespachoManifestacaoModel>().ReverseMap();
            CreateMap<DespachoManifestacaoModel, DespachoManifestacaoViewModel>();
            //.ForMember(x => x.DataSolicitacaoDespacho, opt => opt.MapFrom(src => src.DataSolicitacaoDespacho.ToShortDateString()))
            //.ForMember(x => x.PrazoResposta, opt => opt.MapFrom(src => src.PrazoResposta.ToShortDateString()))
            //.ForMember(x => x.DataRespostaDespacho, opt => opt.MapFrom(src => src.DataRespostaDespacho.HasValue ? ((DateTime)src.DataRespostaDespacho).ToShortDateString() : "")).ReverseMap();
            CreateMap<Manifestacao, ManifestacaoModel>().ReverseMap().PreserveReferences();
            CreateMap<ManifestacaoModel, ManifestacaoViewModel>().ReverseMap();
            CreateMap<ManifestacaoModel, ManifestacaoSimplificadaViewModel>().ReverseMap();
            CreateMap<ComplementoManifestacao, ComplementoManifestacaoModel>().ReverseMap();
            CreateMap<ComplementoManifestacaoModel, ComplementoManifestacaoViewModel>();
            //.ForMember(x => x.DtComplemento, opt => opt.MapFrom(src => src.DtComplemento.HasValue ? ((DateTime)src.DtComplemento).ToShortDateString() : "")).ReverseMap();
            CreateMap<AnexoManifestacao, AnexoManifestacaoModel>().ReverseMap();
            CreateMap<AnexoManifestacaoModel, AnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacao, ArquivoFisicoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacaoModel, ArquivoFisicoAnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<RespostaManifestacao, RespostaManifestacaoModel>().ReverseMap();
            CreateMap<RespostaManifestacaoModel, RespostaManifestacaoViewModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacao, ProrrogacaoManifestacaoModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacaoModel, ProrrogacaoManifestacaoViewModel>();
            //.ForMember(x => x.NovoPrazo, opt => opt.MapFrom(src => src.NovoPrazo.ToShortDateString()))
            //.ForMember(x => x.DataProrrogacao, opt => opt.MapFrom(src => src.DataProrrogacao.ToShortDateString())).ReverseMap();
            CreateMap<ApuracaoManifestacao, ApuracaoManifestacaoModel>().ReverseMap();
            CreateMap<ApuracaoManifestacaoModel, ApuracaoManifestacaoViewModel>();
            //.ForMember(x => x.DataSolicitacaoApuracao, opt => opt.MapFrom(src => src.DataSolicitacaoApuracao.ToShortDateString()))
            //.ForMember(x => x.DataRespostaApuracao, opt => opt.MapFrom(src => src.DataRespostaApuracao.HasValue ? ((DateTime)src.DataRespostaApuracao).ToShortDateString() : "")).ReverseMap();
            CreateMap<EncaminhamentoManifestacao, EncaminhamentoManifestacaoModel>().ReverseMap();
            CreateMap<EncaminhamentoManifestacaoModel, EncaminhamentoManifestacaoViewModel>();
            //.ForMember(x => x.DataEncaminhamento, opt => opt.MapFrom(src => src.DataEncaminhamento.ToShortDateString())).ReverseMap();
            CreateMap<DesdobramentoManifestacao, DesdobramentoManifestacaoModel>().ReverseMap();
            CreateMap<DesdobramentoManifestacaoModel, DesdobramentoManifestacaoViewModel>();
            //.ForMember(x => x.DataDesdobramento, opt => opt.MapFrom(src => src.DataDesdobramento.ToShortDateString())).ReverseMap();
            CreateMap<DiligenciaManifestacao, DiligenciaManifestacaoModel>().ReverseMap();
            CreateMap<DiligenciaManifestacaoModel, DiligenciaManifestacaoViewModel>();
            //.ForMember(x => x.DataDiligencia, opt => opt.MapFrom(src => src.DataDiligencia.ToShortDateString()))
            //.ForMember(x => x.DataRespostaDiligencia, opt => opt.MapFrom(src => src.DataRespostaDiligencia.HasValue ? ((DateTime)src.DataRespostaDiligencia).ToShortDateString() : "")).ReverseMap();
            CreateMap<InterpelacaoManifestacao, InterpelacaoManifestacaoModel>().ReverseMap();
            CreateMap<InterpelacaoManifestacaoModel, InterpelacaoManifestacaoViewModel>();
            //.ForMember(x => x.DataInterpelacao, opt => opt.MapFrom(src => src.DataInterpelacao.ToShortDateString()))
            //.ForMember(x => x.DataRespostaInterpelacao, opt => opt.MapFrom(src => src.DataRespostaInterpelacao.HasValue ? ((DateTime)src.DataRespostaInterpelacao).ToShortDateString() : "")).ReverseMap();
            CreateMap<NotificacaoManifestacao, NotificacaoManifestacaoModel>().ReverseMap();
            CreateMap<NotificacaoManifestacaoModel, NotificacaoManifestacaoViewModel>();
            //.ForMember(x => x.DataNotificacao, opt => opt.MapFrom(src => src.DataNotificacao.ToShortDateString())).ReverseMap();
            CreateMap<AnotacaoManifestacao, AnotacaoManifestacaoModel>().ReverseMap();
            CreateMap<AnotacaoManifestacaoModel, AnotacaoManifestacaoViewModel>();
            //.ForMember(x => x.DataAnotacao, opt => opt.MapFrom(src => src.DataAnotacao.ToShortDateString())).ReverseMap();
            CreateMap<ReclamacaoOmissao, ReclamacaoOmissaoModel>().ReverseMap();
            CreateMap<ReclamacaoOmissaoModel, ReclamacaoOmissaoViewModel>();
            //.ForMember(x => x.DataReclamacaoOmissao, opt => opt.MapFrom(src => src.DataReclamacaoOmissao.ToShortDateString())).ReverseMap();
            //CreateMap<RecursoNegativa, RecursoNegativaModel>().ReverseMap();
            CreateMap<RecursoNegativaModel, RecursoNegativaViewModel>();
            //.ForMember(x => x.DataRecursoNegativa, opt => opt.MapFrom(src => src.DataRecursoNegativa.ToShortDateString()))
            //.ForMember(x => x.DataRespostaRecursoNegativa, opt => opt.MapFrom(src => src.DataRespostaRecursoNegativa.HasValue ? ((DateTime)src.DataRespostaRecursoNegativa).ToShortDateString() : "")).ReverseMap();
            CreateMap<HistoricoManifestacao, HistoricoManifestacaoModel>().ReverseMap();
            CreateMap<HistoricoManifestacaoModel, HistoricoManifestacaoViewModel>().ReverseMap();

            CreateMap<Orgao, OrgaoModel>().ReverseMap();
            CreateMap<OrgaoModel, OrgaoViewModel>().ReverseMap();
            CreateMap<Setor, SetorModel>().ReverseMap();
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioModel, UsuarioViewModel>().ReverseMap();
            CreateMap<Assunto, AssuntoModel>().ReverseMap();
            CreateMap<AssuntoModel, AssuntoViewModel>().ReverseMap();
            CreateMap<CanalEntrada, CanalEntradaModel>().ReverseMap();
            CreateMap<CanalEntradaModel, CanalEntradaViewModel>().ReverseMap();
            CreateMap<ModoResposta, ModoRespostaModel>().ReverseMap();
            CreateMap<ModoRespostaModel, ModoRespostaViewModel>().ReverseMap();
            CreateMap<Municipio, MunicipioModel>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioViewModel>().ReverseMap();
            CreateMap<Uf, UfModel>().ReverseMap();
            CreateMap<UfModel, UfViewModel>().ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaModel>().ReverseMap();
            CreateMap<PessoaJuridicaModel, PessoaJuridicaViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaModel>().ReverseMap();
            CreateMap<PessoaModel, PessoaViewModel>().ReverseMap();
            CreateMap<ResultadoResposta, ResultadoRespostaModel>().ReverseMap();
            CreateMap<SituacaoManifestacao, SituacaoManifestacaoModel>().ReverseMap();
            CreateMap<SituacaoManifestacaoModel, SituacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<TipoIdentificacao, TipoIdentificacaoModel>().ReverseMap();
            CreateMap<TipoIdentificacaoModel, TipoIdentificacaoViewModel>().ReverseMap();
            CreateMap<TipoManifestacao, TipoManifestacaoModel>().ReverseMap();
            CreateMap<TipoManifestacaoModel, TipoManifestacaoViewModel>().ReverseMap();
            CreateMap<TipoManifestante, TipoManifestanteModel>().ReverseMap();
            CreateMap<TipoManifestanteModel, TipoManifestanteViewModel>().ReverseMap();
            CreateMap<TipoAnexoManifestacao, TipoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<Perfil, PerfilModel>().ReverseMap();
            CreateMap<AgenteManifestacao, AgenteManifestacaoModel>().ReverseMap();

            //Mapeamento de objetos customizados
            CreateMap<FiltroDadosManifestacaoSelecionadosEntry, FiltroDadosManifestacaoModel>().ReverseMap();
        }
    }
}