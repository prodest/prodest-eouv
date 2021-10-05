using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class DiligenciaManifestacao
    {
        public int IdDiligenciaManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtDiligencia { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataDiligencia { get; set; }
        public string TxtRespostaDiligencia { get; set; }
        public DateTime? DataRespostaDiligencia { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}