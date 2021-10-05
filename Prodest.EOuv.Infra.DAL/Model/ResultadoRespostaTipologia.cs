#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ResultadoRespostaTipologia
    {
        public int IdResultadoRespostaTipologia { get; set; }
        public int IdResultadoResposta { get; set; }
        public int IdTipoManifestacao { get; set; }

        public virtual ResultadoResposta ResultadoResposta { get; set; }
        public virtual TipoManifestacao TipoManifestacao { get; set; }
    }
}