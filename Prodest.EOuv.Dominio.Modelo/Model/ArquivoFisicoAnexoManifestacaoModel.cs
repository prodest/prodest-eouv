#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ArquivoFisicoAnexoManifestacaoModel
    {
        public int IdArquivoFisicoAnexoManifestacao { get; set; }
        public int IdAnexoManifestacao { get; set; }
        public byte[] Conteudo { get; set; }
    }
}