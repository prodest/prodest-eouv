using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class TipoManifestacaoModel
    {
        public int IdTipoManifestacao { get; set; }
        public string DescTipoManifestacao { get; set; }
        public int? DiasPrazo { get; set; }
        public int? DiasProrrogacao { get; set; }
        public int? DiasDiligencia { get; set; }
        public int? DiasInterpelacao { get; set; }
        public int? DiasReclamacaoOmissao { get; set; }
        public int? DiasRecursoNegativa { get; set; }
    }
}