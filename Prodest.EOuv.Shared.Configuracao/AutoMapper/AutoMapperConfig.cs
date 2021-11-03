using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao;
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
            CreateMap<Manifestacao, ManifestacaoModel>().ReverseMap().PreserveReferences();
            CreateMap<ManifestacaoModel, ManifestacaoViewModel>().ReverseMap();
            CreateMap<ManifestacaoModel, ManifestacaoSimplificadaViewModel>().ReverseMap();
            CreateMap<ComplementoManifestacao, ComplementoManifestacaoModel>().ReverseMap();
            CreateMap<ComplementoManifestacaoModel, ComplementoManifestacaoViewModel>();
            CreateMap<AnexoManifestacao, AnexoManifestacaoModel>().ReverseMap();
            CreateMap<AnexoManifestacaoModel, AnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacao, ArquivoFisicoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<ArquivoFisicoAnexoManifestacaoModel, ArquivoFisicoAnexoManifestacaoViewModel>().ReverseMap();
            CreateMap<RespostaManifestacao, RespostaManifestacaoModel>().ReverseMap();
            CreateMap<RespostaManifestacaoModel, RespostaManifestacaoViewModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacao, ProrrogacaoManifestacaoModel>().ReverseMap();
            CreateMap<ProrrogacaoManifestacaoModel, ProrrogacaoManifestacaoViewModel>();
            CreateMap<ApuracaoManifestacao, ApuracaoManifestacaoModel>().ReverseMap();
            CreateMap<ApuracaoManifestacaoModel, ApuracaoManifestacaoViewModel>();
            CreateMap<EncaminhamentoManifestacao, EncaminhamentoManifestacaoModel>().ReverseMap();
            CreateMap<EncaminhamentoManifestacaoModel, EncaminhamentoManifestacaoViewModel>();
            CreateMap<DesdobramentoManifestacao, DesdobramentoManifestacaoModel>().ReverseMap();
            CreateMap<DesdobramentoManifestacaoModel, DesdobramentoManifestacaoViewModel>();
            CreateMap<DiligenciaManifestacao, DiligenciaManifestacaoModel>().ReverseMap();
            CreateMap<DiligenciaManifestacaoModel, DiligenciaManifestacaoViewModel>();
            CreateMap<InterpelacaoManifestacao, InterpelacaoManifestacaoModel>().ReverseMap();
            CreateMap<InterpelacaoManifestacaoModel, InterpelacaoManifestacaoViewModel>();
            CreateMap<NotificacaoManifestacao, NotificacaoManifestacaoModel>().ReverseMap();
            CreateMap<NotificacaoManifestacaoModel, NotificacaoManifestacaoViewModel>();
            CreateMap<AnotacaoManifestacao, AnotacaoManifestacaoModel>().ReverseMap();
            CreateMap<AnotacaoManifestacaoModel, AnotacaoManifestacaoViewModel>();
            CreateMap<ReclamacaoOmissao, ReclamacaoOmissaoModel>().ReverseMap();
            CreateMap<ReclamacaoOmissaoModel, ReclamacaoOmissaoViewModel>();
            CreateMap<RecursoNegativa, RecursoNegativaModel>();
            CreateMap<RecursoNegativaModel, RecursoNegativaViewModel>();
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
            CreateMap<ResultadoRespostaModel, ResultadoRespostaViewModel>().ReverseMap();
            CreateMap<SituacaoManifestacao, SituacaoManifestacaoModel>().ReverseMap();
            CreateMap<SituacaoManifestacaoModel, SituacaoManifestacaoViewModel>().ReverseMap();
            CreateMap<SituacaoDespacho, SituacaoDespachoModel>().ReverseMap();
            CreateMap<SituacaoDespachoModel, SituacaoDespachoViewModel>().ReverseMap();
            CreateMap<TipoIdentificacao, TipoIdentificacaoModel>().ReverseMap();
            CreateMap<TipoIdentificacaoModel, TipoIdentificacaoViewModel>().ReverseMap();
            CreateMap<TipoManifestacao, TipoManifestacaoModel>().ReverseMap();
            CreateMap<TipoManifestacaoModel, TipoManifestacaoViewModel>().ReverseMap();
            CreateMap<TipoManifestante, TipoManifestanteModel>().ReverseMap();
            CreateMap<TipoManifestanteModel, TipoManifestanteViewModel>().ReverseMap();
            CreateMap<TipoAnexoManifestacao, TipoAnexoManifestacaoModel>().ReverseMap();
            CreateMap<Perfil, PerfilModel>().ReverseMap();
            CreateMap<AgenteManifestacao, AgenteManifestacaoModel>().ReverseMap();
            CreateMap<AgenteManifestacaoModel, AgenteManifestacaoViewModel>().ReverseMap();
            CreateMap<ResultadoResposta, ResultadoRespostaModel>().ReverseMap();
            CreateMap<ResultadoRespostaModel, ResultadoRespostaViewModel>().ReverseMap();
            CreateMap<UsuarioLogado, UsuarioLogadoModel>()
                .ForMember(x => x.IdExterno, opt => opt.MapFrom(src => src.Sub)).ReverseMap();
            CreateMap<PapelLogado, PapelLogadoModel>()
                .ForMember(x => x.IdExterno, opt => opt.MapFrom(src => src.Guid))
                .ForMember(x => x.TipoPapel, opt => opt.MapFrom(src => src.Tipo)).ReverseMap();

            //Mapeamento de objetos customizados
            CreateMap<FiltroDadosManifestacaoSelecionadosEntry, FiltroDadosManifestacaoModel>().ReverseMap();
            CreateMap<RespostaManifestacaoEntry, RespostaManifestacaoEntryModel>().ReverseMap();
        }
    }
}