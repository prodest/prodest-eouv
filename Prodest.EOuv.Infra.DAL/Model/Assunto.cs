using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Assunto
    {
        public Assunto()
        {
            AtendimentoImediato = new HashSet<AtendimentoImediato>();
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdAssunto { get; set; }
        public string DescAssunto { get; set; }
        public bool IndAssuntoGeral { get; set; }
        public bool? IndAssuntoSic { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}