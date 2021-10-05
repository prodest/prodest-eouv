using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class HistoricoManifestacao
    {
        public int IdHistoricoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int? IdOrgao { get; set; }
        public int? IdSetor { get; set; }
        public int IdSituacao { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataHistorico { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual SituacaoManifestacao SituacaoManifestacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}