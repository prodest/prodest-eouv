using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class TipoIdentificacao
    {
        public TipoIdentificacao()
        {
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdTipoIdentificacao { get; set; }
        public string DescTipoIdentificacao { get; set; }

        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}