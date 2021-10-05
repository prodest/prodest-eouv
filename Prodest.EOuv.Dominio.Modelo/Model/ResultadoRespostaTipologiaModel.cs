#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ResultadoRespostaTipologiaModel
    {
        public int IdResultadoRespostaTipologia { get; set; }
        public int IdResultadoResposta { get; set; }
        public int IdTipoManifestacao { get; set; }

        public virtual ResultadoRespostaModel ResultadoResposta { get; set; }
        public virtual TipoManifestacaoModel TipoManifestacao { get; set; }
    }
}