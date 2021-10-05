using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class CanalEntrada
    {
        public CanalEntrada()
        {
            AtendimentoImediato = new HashSet<AtendimentoImediato>();
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdCanalEntrada { get; set; }
        public string DescCanalEntrada { get; set; }

        public virtual ICollection<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}