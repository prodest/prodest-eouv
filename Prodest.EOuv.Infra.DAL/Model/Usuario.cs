using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Usuario
    {
        public Usuario()
        {
            AnotacaoManifestacao = new HashSet<AnotacaoManifestacao>();
            ApuracaoManifestacaoUsuarioRespostaApuracao = new HashSet<ApuracaoManifestacao>();
            ApuracaoManifestacaoUsuarioSolicitacaoApuracao = new HashSet<ApuracaoManifestacao>();
            ArquivamentoManifestacao = new HashSet<ArquivamentoManifestacao>();
            AtendimentoImediato = new HashSet<AtendimentoImediato>();
            ComplementoManifestacao = new HashSet<ComplementoManifestacao>();
            DesdobramentoManifestacao = new HashSet<DesdobramentoManifestacao>();
            DespachoManifestacao = new HashSet<DespachoManifestacao>();
            DiligenciaManifestacao = new HashSet<DiligenciaManifestacao>();
            EncaminhamentoManifestacao = new HashSet<EncaminhamentoManifestacao>();
            HistoricoManifestacao = new HashSet<HistoricoManifestacao>();
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacao>();
            LogAcesso = new HashSet<LogAcesso>();
            ManifestacaoUsuarioAnalise = new HashSet<Manifestacao>();
            ManifestacaoUsuarioCadastrador = new HashSet<Manifestacao>();
            ManifestacaoUsuario = new HashSet<Manifestacao>();
            NotificacaoManifestacao = new HashSet<NotificacaoManifestacao>();
            ProrrogacaoManifestacao = new HashSet<ProrrogacaoManifestacao>();
            RecursoNegativa = new HashSet<RecursoNegativa>();
            RespostaManifestacao = new HashSet<RespostaManifestacao>();
        }

        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int IdPessoa { get; set; }
        public int? IdOrgao { get; set; }
        public string Login { get; set; }
        public DateTime DatCadastro { get; set; }
        public bool IndUsuarioServidor { get; set; }
        public bool IndUsuarioSistema { get; set; }

        public virtual Orgao Orgao { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<AnotacaoManifestacao> AnotacaoManifestacao { get; set; }
        public virtual ICollection<ApuracaoManifestacao> ApuracaoManifestacaoUsuarioRespostaApuracao { get; set; }
        public virtual ICollection<ApuracaoManifestacao> ApuracaoManifestacaoUsuarioSolicitacaoApuracao { get; set; }
        public virtual ICollection<ArquivamentoManifestacao> ArquivamentoManifestacao { get; set; }
        public virtual ICollection<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual ICollection<ComplementoManifestacao> ComplementoManifestacao { get; set; }
        public virtual ICollection<DesdobramentoManifestacao> DesdobramentoManifestacao { get; set; }
        public virtual ICollection<DespachoManifestacao> DespachoManifestacao { get; set; }
        public virtual ICollection<DiligenciaManifestacao> DiligenciaManifestacao { get; set; }
        public virtual ICollection<EncaminhamentoManifestacao> EncaminhamentoManifestacao { get; set; }
        public virtual ICollection<HistoricoManifestacao> HistoricoManifestacao { get; set; }
        public virtual ICollection<InterpelacaoManifestacao> InterpelacaoManifestacao { get; set; }
        public virtual ICollection<LogAcesso> LogAcesso { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoUsuarioAnalise { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoUsuarioCadastrador { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoUsuario { get; set; }
        public virtual ICollection<NotificacaoManifestacao> NotificacaoManifestacao { get; set; }
        public virtual ICollection<ProrrogacaoManifestacao> ProrrogacaoManifestacao { get; set; }
        public virtual ICollection<RecursoNegativa> RecursoNegativa { get; set; }
        public virtual ICollection<RespostaManifestacao> RespostaManifestacao { get; set; }
    }
}