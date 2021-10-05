using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class AnotacaoManifestacao
    {
        public int IdAnotacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtAnotacao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAnotacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}