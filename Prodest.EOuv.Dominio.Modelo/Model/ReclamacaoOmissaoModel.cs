using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ReclamacaoOmissaoModel
    {
        public int IdReclamacaoOmissao { get; set; }
        public int IdManifestacaoPai { get; set; }
        public int IdManifestacaoFilha { get; set; }
        public DateTime DataReclamacaoOmissao { get; set; }

        public virtual ManifestacaoModel ManifestacaoFilha { get; set; }
        public virtual ManifestacaoModel ManifestacaoPai { get; set; }
    }
}