using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ManifestacaoModel
    {
        public ManifestacaoModel()
        {
            AnexoManifestacao = new HashSet<AnexoManifestacaoModel>();
            AnotacaoManifestacao = new HashSet<AnotacaoManifestacaoModel>();
            ApuracaoManifestacao = new HashSet<ApuracaoManifestacaoModel>();
            ArquivamentoManifestacao = new HashSet<ArquivamentoManifestacaoModel>();
            ComplementoManifestacao = new HashSet<ComplementoManifestacaoModel>();
            DesdobramentoManifestacaoManifestacaoFilha = new HashSet<DesdobramentoManifestacaoModel>();
            DesdobramentoManifestacaoManifestacaoPai = new HashSet<DesdobramentoManifestacaoModel>();
            DespachoManifestacao = new HashSet<DespachoManifestacaoModel>();
            DiligenciaManifestacao = new HashSet<DiligenciaManifestacaoModel>();
            EncaminhamentoManifestacao = new HashSet<EncaminhamentoManifestacaoModel>();
            HistoricoManifestacao = new HashSet<HistoricoManifestacaoModel>();
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacaoModel>();
            NotificacaoManifestacao = new HashSet<NotificacaoManifestacaoModel>();
            PesquisaSatisfacao = new HashSet<PesquisaSatisfacaoModel>();
            ProrrogacaoManifestacao = new HashSet<ProrrogacaoManifestacaoModel>();
            ReclamacaoOmissaoManifestacaoFilha = new HashSet<ReclamacaoOmissaoModel>();
            ReclamacaoOmissaoManifestacaoPai = new HashSet<ReclamacaoOmissaoModel>();
            RecursoNegativa = new HashSet<RecursoNegativaModel>();
            RespostaManifestacao = new HashSet<RespostaManifestacaoModel>();
        }

        public int IdManifestacao { get; set; }
        public string NumProtocolo { get; set; }
        public string Senha { get; set; }
        public int? IdPessoa { get; set; }
        public int? IdUsuario { get; set; }
        public int IdTipoManifestacao { get; set; }
        public int IdTipoIdentificacao { get; set; }
        public int? IdTipoManifestante { get; set; }
        public int IdAssunto { get; set; }
        public int IdOrgaoInteresse { get; set; }
        public int IdOrgaoResponsavel { get; set; }
        public int? IdCanalEntrada { get; set; }
        public int? IdModoResposta { get; set; }
        public string TextoManifestacao { get; set; }
        public int IdMunicipio { get; set; }
        public int IdSituacaoManifestacao { get; set; }
        public bool? IndProrrogada { get; set; }
        public int? IdUsuarioAnalise { get; set; }
        public int? IdUsuarioCadastrador { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? PrazoResposta { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public int? IdResultadoResposta { get; set; }
        public int? IdOrgaoCompetenciaFato { get; set; }
        public int? IdPessoaJuridica { get; set; }

        public virtual AssuntoModel Assunto { get; set; }
        public virtual CanalEntradaModel CanalEntrada { get; set; }
        public virtual ModoRespostaModel ModoResposta { get; set; }
        public virtual OrgaoModel OrgaoCompetenciaFato { get; set; }
        public virtual OrgaoModel OrgaoInteresse { get; set; }
        public virtual OrgaoModel OrgaoResponsavel { get; set; }
        public virtual PessoaJuridicaModel PessoaJuridica { get; set; }
        public virtual PessoaModel Pessoa { get; set; }
        public virtual ResultadoRespostaModel ResultadoResposta { get; set; }
        public virtual SituacaoManifestacaoModel SituacaoManifestacao { get; set; }
        public virtual TipoIdentificacaoModel TipoIdentificacao { get; set; }
        public virtual TipoManifestacaoModel TipoManifestacao { get; set; }
        public virtual TipoManifestanteModel TipoManifestante { get; set; }
        public virtual UsuarioModel UsuarioAnalise { get; set; }
        public virtual UsuarioModel UsuarioCadastrador { get; set; }
        public virtual UsuarioModel Usuario { get; set; }

        public virtual ICollection<AnexoManifestacaoModel> AnexoManifestacao { get; set; }
        public virtual ICollection<AnotacaoManifestacaoModel> AnotacaoManifestacao { get; set; }
        public virtual ICollection<ApuracaoManifestacaoModel> ApuracaoManifestacao { get; set; }
        public virtual ICollection<ArquivamentoManifestacaoModel> ArquivamentoManifestacao { get; set; }
        public virtual ICollection<ComplementoManifestacaoModel> ComplementoManifestacao { get; set; }
        public virtual ICollection<DesdobramentoManifestacaoModel> DesdobramentoManifestacaoManifestacaoFilha { get; set; }
        public virtual ICollection<DesdobramentoManifestacaoModel> DesdobramentoManifestacaoManifestacaoPai { get; set; }
        public virtual ICollection<DespachoManifestacaoModel> DespachoManifestacao { get; set; }
        public virtual ICollection<DiligenciaManifestacaoModel> DiligenciaManifestacao { get; set; }
        public virtual ICollection<EncaminhamentoManifestacaoModel> EncaminhamentoManifestacao { get; set; }
        public virtual ICollection<HistoricoManifestacaoModel> HistoricoManifestacao { get; set; }
        public virtual ICollection<InterpelacaoManifestacaoModel> InterpelacaoManifestacao { get; set; }
        public virtual ICollection<NotificacaoManifestacaoModel> NotificacaoManifestacao { get; set; }
        public virtual ICollection<PesquisaSatisfacaoModel> PesquisaSatisfacao { get; set; }
        public virtual ICollection<ProrrogacaoManifestacaoModel> ProrrogacaoManifestacao { get; set; }
        public virtual ICollection<ReclamacaoOmissaoModel> ReclamacaoOmissaoManifestacaoFilha { get; set; }
        public virtual ICollection<ReclamacaoOmissaoModel> ReclamacaoOmissaoManifestacaoPai { get; set; }
        public virtual ICollection<RecursoNegativaModel> RecursoNegativa { get; set; }
        public virtual ICollection<RespostaManifestacaoModel> RespostaManifestacao { get; set; }
    }
}