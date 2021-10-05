using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class DesdobramentoManifestacao
    {
        public int IdDesdobramentoManifestacao { get; set; }
        public int IdManifestacaoPai { get; set; }
        public int IdManifestacaoFilha { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataDesdobramento { get; set; }

        public virtual Manifestacao ManifestacaoFilha { get; set; }
        public virtual Manifestacao ManifestacaoPai { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}