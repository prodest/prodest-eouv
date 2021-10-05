using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ReclamacaoOmissao
    {
        public int IdReclamacaoOmissao { get; set; }
        public int IdManifestacaoPai { get; set; }
        public int IdManifestacaoFilha { get; set; }
        public DateTime DataReclamacaoOmissao { get; set; }

        public virtual Manifestacao ManifestacaoFilha { get; set; }
        public virtual Manifestacao ManifestacaoPai { get; set; }
    }
}