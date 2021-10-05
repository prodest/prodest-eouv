using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ModoResposta
    {
        public ModoResposta()
        {
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdModoResposta { get; set; }
        public string DescModoResposta { get; set; }

        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}