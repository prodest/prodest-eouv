using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Orgao
    {
        public Orgao()
        {
            ApuracaoManifestacaoOrgaoDestino = new HashSet<ApuracaoManifestacao>();
            ApuracaoManifestacaoOrgaoOrigem = new HashSet<ApuracaoManifestacao>();
            DesdobramentoManifestacao = new HashSet<DesdobramentoManifestacao>();
            DespachoManifestacao = new HashSet<DespachoManifestacao>();
            DiligenciaManifestacao = new HashSet<DiligenciaManifestacao>();
            EncaminhamentoManifestacaoOrgaoDestino = new HashSet<EncaminhamentoManifestacao>();
            EncaminhamentoManifestacaoOrgaoOrigem = new HashSet<EncaminhamentoManifestacao>();
            HistoricoManifestacao = new HashSet<HistoricoManifestacao>();
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacao>();
            ManifestacaoOrgaoCompetenciaFato = new HashSet<Manifestacao>();
            ManifestacaoOrgaoInteresse = new HashSet<Manifestacao>();
            ManifestacaoOrgaoResponsavel = new HashSet<Manifestacao>();
            NotificacaoManifestacao = new HashSet<NotificacaoManifestacao>();
            Ouvidoria = new HashSet<Ouvidoria>();
            ProrrogacaoManifestacao = new HashSet<ProrrogacaoManifestacao>();
            RespostaManifestacao = new HashSet<RespostaManifestacao>();
            Setor = new HashSet<Setor>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdOrgao { get; set; }
        public Guid GuidOrgao { get; set; }
        public string SiglaOrgao { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DatAtualizacao { get; set; }
        public bool IndAtivo { get; set; }
        public bool IndOutrasCompetencias { get; set; }
        public bool IndInsercaoManual { get; set; }

        public virtual ICollection<ApuracaoManifestacao> ApuracaoManifestacaoOrgaoDestino { get; set; }
        public virtual ICollection<ApuracaoManifestacao> ApuracaoManifestacaoOrgaoOrigem { get; set; }
        public virtual ICollection<DesdobramentoManifestacao> DesdobramentoManifestacao { get; set; }
        public virtual ICollection<DespachoManifestacao> DespachoManifestacao { get; set; }
        public virtual ICollection<DiligenciaManifestacao> DiligenciaManifestacao { get; set; }
        public virtual ICollection<EncaminhamentoManifestacao> EncaminhamentoManifestacaoOrgaoDestino { get; set; }
        public virtual ICollection<EncaminhamentoManifestacao> EncaminhamentoManifestacaoOrgaoOrigem { get; set; }
        public virtual ICollection<HistoricoManifestacao> HistoricoManifestacao { get; set; }
        public virtual ICollection<InterpelacaoManifestacao> InterpelacaoManifestacao { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoOrgaoCompetenciaFato { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoOrgaoInteresse { get; set; }
        public virtual ICollection<Manifestacao> ManifestacaoOrgaoResponsavel { get; set; }
        public virtual ICollection<NotificacaoManifestacao> NotificacaoManifestacao { get; set; }
        public virtual ICollection<Ouvidoria> Ouvidoria { get; set; }
        public virtual ICollection<ProrrogacaoManifestacao> ProrrogacaoManifestacao { get; set; }
        public virtual ICollection<RespostaManifestacao> RespostaManifestacao { get; set; }
        public virtual ICollection<Setor> Setor { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}