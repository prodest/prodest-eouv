using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class TipoManifestacao
    {
        public TipoManifestacao()
        {
            AtendimentoImediato = new HashSet<AtendimentoImediato>();
            Manifestacao = new HashSet<Manifestacao>();
            ResultadoRespostaTipologia = new HashSet<ResultadoRespostaTipologia>();
        }

        public int IdTipoManifestacao { get; set; }
        public string DescTipoManifestacao { get; set; }
        public int? DiasPrazo { get; set; }
        public int? DiasProrrogacao { get; set; }
        public int? DiasDiligencia { get; set; }
        public int? DiasInterpelacao { get; set; }
        public int? DiasReclamacaoOmissao { get; set; }
        public int? DiasRecursoNegativa { get; set; }

        public virtual ICollection<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
        public virtual ICollection<ResultadoRespostaTipologia> ResultadoRespostaTipologia { get; set; }
    }
}