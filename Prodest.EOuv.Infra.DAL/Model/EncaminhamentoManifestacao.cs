using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class EncaminhamentoManifestacao
    {
        public int IdEncaminhamentoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int IdOrgaoOrigem { get; set; }
        public int IdOrgaoDestino { get; set; }
        public string TxtEncaminhamento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataEncaminhamento { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao OrgaoDestino { get; set; }
        public virtual Orgao OrgaoOrigem { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}