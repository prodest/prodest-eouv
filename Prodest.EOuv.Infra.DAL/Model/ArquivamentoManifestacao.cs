using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ArquivamentoManifestacao
    {
        public int IdArquivamentoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtJustificativaArquivamento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataArquivamento { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}