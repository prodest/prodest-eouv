using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class TipoManifestante
    {
        public TipoManifestante()
        {
            AtendimentoImediato = new HashSet<AtendimentoImediato>();
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdTipoManifestante { get; set; }
        public string DescTipoManifestante { get; set; }

        public virtual ICollection<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}