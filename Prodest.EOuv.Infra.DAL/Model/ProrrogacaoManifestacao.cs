using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ProrrogacaoManifestacao
    {
        public int IdProrrogacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtJustificativaProrrogacao { get; set; }
        public DateTime PrazoOriginal { get; set; }
        public DateTime NovoPrazo { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataProrrogacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}