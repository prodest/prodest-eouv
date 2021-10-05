using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ApuracaoManifestacaoModel
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

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel OrgaoDestino { get; set; }

        public virtual OrgaoModel OrgaoOrigem { get; set; }
        public virtual UsuarioModel UsuarioRespostaApuracao { get; set; }
        public virtual UsuarioModel UsuarioSolicitacaoApuracao { get; set; }
    }
}