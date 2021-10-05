using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ApuracaoManifestacao
    {
        public int IdApuracaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtSolicitacaoApuracao { get; set; }
        public int IdUsuarioSolicitacaoApuracao { get; set; }
        public DateTime DataSolicitacaoApuracao { get; set; }
        public int IdOrgaoOrigem { get; set; }
        public int IdOrgaoDestino { get; set; }
        public string TxtRespostaApuracao { get; set; }
        public int? IdUsuarioRespostaApuracao { get; set; }
        public DateTime? DataRespostaApuracao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao OrgaoDestino { get; set; }
        public virtual Orgao OrgaoOrigem { get; set; }
        public virtual Usuario UsuarioRespostaApuracao { get; set; }
        public virtual Usuario UsuarioSolicitacaoApuracao { get; set; }
    }
}