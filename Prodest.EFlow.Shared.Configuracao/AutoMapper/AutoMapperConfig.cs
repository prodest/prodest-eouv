using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Infra.DAL;
using Prodest.EOuv.UI.Apresentacao;

namespace Prodest.EOuv.Shared.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<DespachoManifestacao, DespachoManifestacaoModel>().ReverseMap();
            CreateMap<DespachoManifestacaoModel, DespachoManifestacaoViewModel>().ReverseMap();
            CreateMap<Manifestacao, ManifestacaoModel>().ReverseMap().PreserveReferences();
            CreateMap<ManifestacaoModel, ManifestacaoViewModel>().ReverseMap();
            CreateMap<ManifestacaoModel, ManifestacaoSimplificadaViewModel>().ReverseMap();
            CreateMap<ComplementoManifestacao, ComplementoManifestacaoModel>().ReverseMap();
            CreateMap<ComplementoManifestacaoModel, ComplementoManifestacaoViewModel>().ReverseMap();
            CreateMap<AnexoManifestacao, AnexoManifestacaoModel>().ReverseMap();
            CreateMap<AnexoManifestacaoModel, AnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacao, ArquivoFisicoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacaoModel, ArquivoFisicoAnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<RespostaManifestacao, RespostaManifestacaoModel>().ReverseMap();
            CreateMap<RespostaManifestacaoModel, RespostaManifestacaoViewModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacao, ProrrogacaoManifestacaoModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacaoModel, ProrrogacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<ApuracaoManifestacao, ApuracaoManifestacaoModel>().ReverseMap();
            CreateMap<ApuracaoManifestacaoModel, ApuracaoManifestacaoViewModel>().ReverseMap();
            CreateMap<EncaminhamentoManifestacao, EncaminhamentoManifestacaoModel>().ReverseMap();
            CreateMap<EncaminhamentoManifestacaoModel, EncaminhamentoManifestacaoViewModel>().ReverseMap();
            CreateMap<DesdobramentoManifestacao, DesdobramentoManifestacaoModel>().ReverseMap();
            CreateMap<DesdobramentoManifestacaoModel, DesdobramentoManifestacaoViewModel>().ReverseMap();
            CreateMap<DiligenciaManifestacao, DiligenciaManifestacaoModel>().ReverseMap();
            CreateMap<DiligenciaManifestacaoModel, DiligenciaManifestacaoViewModel>().ReverseMap();
            CreateMap<InterpelacaoManifestacao, InterpelacaoManifestacaoModel>().ReverseMap();
            CreateMap<InterpelacaoManifestacaoModel, InterpelacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<NotificacaoManifestacao, NotificacaoManifestacaoModel>().ReverseMap();
            CreateMap<NotificacaoManifestacaoModel, NotificacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<AnotacaoManifestacao, AnotacaoManifestacaoModel>().ReverseMap();
            CreateMap<AnotacaoManifestacaoModel, AnotacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<ReclamacaoOmissao, ReclamacaoOmissaoModel>().ReverseMap();
            CreateMap<ReclamacaoOmissaoModel, ReclamacaoOmissaoViewModel>().ReverseMap();
            CreateMap<RecursoNegativa, RecursoNegativaModel>().ReverseMap();
            CreateMap<RecursoNegativaModel, RecursoNegativaViewModel>().ReverseMap();
            CreateMap<HistoricoManifestacao, HistoricoManifestacaoModel>().ReverseMap();
            CreateMap<HistoricoManifestacaoModel, HistoricoManifestacaoViewModel>().ReverseMap();

            CreateMap<Orgao, OrgaoModel>().ReverseMap();
            CreateMap<OrgaoModel, OrgaoViewModel>().ReverseMap();
            CreateMap<Setor, SetorModel>().ReverseMap();
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<Assunto, AssuntoModel>().ReverseMap();
            CreateMap<CanalEntrada, CanalEntradaModel>().ReverseMap();
            CreateMap<ModoResposta, ModoRespostaModel>().ReverseMap();
            CreateMap<Municipio, MunicipioModel>().ReverseMap();
            CreateMap<Uf, UfModel>().ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaModel>().ReverseMap();
            CreateMap<Pessoa, PessoaModel>().ReverseMap();
            CreateMap<ResultadoResposta, ResultadoRespostaModel>().ReverseMap();
            CreateMap<SituacaoManifestacao, SituacaoManifestacaoModel>().ReverseMap();
            CreateMap<SituacaoManifestacaoModel, SituacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<TipoIdentificacao, TipoIdentificacaoModel>().ReverseMap();
            CreateMap<TipoManifestacao, TipoManifestacaoModel>().ReverseMap();
            CreateMap<TipoManifestante, TipoManifestanteModel>().ReverseMap();
            CreateMap<TipoAnexoManifestacao, TipoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<Perfil, PerfilModel>().ReverseMap();
        }
    }
}