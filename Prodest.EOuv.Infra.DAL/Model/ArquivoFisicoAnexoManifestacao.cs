#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ArquivoFisicoAnexoManifestacao
    {
        public int IdArquivoFisicoAnexoManifestacao { get; set; }
        public int IdAnexoManifestacao { get; set; }
        public byte[] Conteudo { get; set; }

        public virtual AnexoManifestacao AnexoManifestacao { get; set; }
    }
}