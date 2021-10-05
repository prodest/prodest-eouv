using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Manifestacao
    {
        public Manifestacao()
        {
            AnexoManifestacao = new HashSet<AnexoManifestacao>();
            AnotacaoManifestacao = new HashSet<AnotacaoManifestacao>();
            ApuracaoManifestacao = new HashSet<ApuracaoManifestacao>();
            ArquivamentoManifestacao = new HashSet<ArquivamentoManifestacao>();
            ComplementoManifestacao = new HashSet<ComplementoManifestacao>();
            DesdobramentoManifestacaoManifestacaoFilha = new HashSet<DesdobramentoManifestacao>();
            DesdobramentoManifestacaoManifestacaoPai = new HashSet<DesdobramentoManifestacao>();
            DespachoManifestacao = new HashSet<DespachoManifestacao>();
            DiligenciaManifestacao = new HashSet<DiligenciaManifestacao>();
            EncaminhamentoManifestacao = new HashSet<EncaminhamentoManifestacao>();
            HistoricoManifestacao = new HashSet<HistoricoManifestacao>();
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacao>();
            NotificacaoManifestacao = new HashSet<NotificacaoManifestacao>();
            PesquisaSatisfacao = new HashSet<PesquisaSatisfacao>();
            ProrrogacaoManifestacao = new HashSet<ProrrogacaoManifestacao>();
            ReclamacaoOmissaoManifestacaoFilha = new HashSet<ReclamacaoOmissao>();
            ReclamacaoOmissaoManifestacaoPai = new HashSet<ReclamacaoOmissao>();
            RecursoNegativa = new HashSet<RecursoNegativa>();
            RespostaManifestacao = new HashSet<RespostaManifestacao>();
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

        public virtual Assunto Assunto { get; set; }
        public virtual CanalEntrada CanalEntrada { get; set; }
        public virtual ModoResposta ModoResposta { get; set; }
        public virtual Orgao OrgaoCompetenciaFato { get; set; }
        public virtual Orgao OrgaoInteresse { get; set; }
        public virtual Orgao OrgaoResponsavel { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ResultadoResposta ResultadoResposta { get; set; }
        public virtual SituacaoManifestacao SituacaoManifestacao { get; set; }
        public virtual TipoIdentificacao TipoIdentificacao { get; set; }
        public virtual TipoManifestacao TipoManifestacao { get; set; }
        public virtual TipoManifestante TipoManifestante { get; set; }
        public virtual Usuario UsuarioAnalise { get; set; }
        public virtual Usuario UsuarioCadastrador { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<AnexoManifestacao> AnexoManifestacao { get; set; }
        public virtual ICollection<AnotacaoManifestacao> AnotacaoManifestacao { get; set; }
        public virtual ICollection<ApuracaoManifestacao> ApuracaoManifestacao { get; set; }
        public virtual ICollection<ArquivamentoManifestacao> ArquivamentoManifestacao { get; set; }
        public virtual ICollection<ComplementoManifestacao> ComplementoManifestacao { get; set; }
        public virtual ICollection<DesdobramentoManifestacao> DesdobramentoManifestacaoManifestacaoFilha { get; set; }
        public virtual ICollection<DesdobramentoManifestacao> DesdobramentoManifestacaoManifestacaoPai { get; set; }
        public virtual ICollection<DespachoManifestacao> DespachoManifestacao { get; set; }
        public virtual ICollection<DiligenciaManifestacao> DiligenciaManifestacao { get; set; }
        public virtual ICollection<EncaminhamentoManifestacao> EncaminhamentoManifestacao { get; set; }
        public virtual ICollection<HistoricoManifestacao> HistoricoManifestacao { get; set; }
        public virtual ICollection<InterpelacaoManifestacao> InterpelacaoManifestacao { get; set; }
        public virtual ICollection<NotificacaoManifestacao> NotificacaoManifestacao { get; set; }
        public virtual ICollection<PesquisaSatisfacao> PesquisaSatisfacao { get; set; }
        public virtual ICollection<ProrrogacaoManifestacao> ProrrogacaoManifestacao { get; set; }
        public virtual ICollection<ReclamacaoOmissao> ReclamacaoOmissaoManifestacaoFilha { get; set; }
        public virtual ICollection<ReclamacaoOmissao> ReclamacaoOmissaoManifestacaoPai { get; set; }
        public virtual ICollection<RecursoNegativa> RecursoNegativa { get; set; }
        public virtual ICollection<RespostaManifestacao> RespostaManifestacao { get; set; }
    }
}