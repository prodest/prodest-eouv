using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class SituacaoManifestacao
    {
        public SituacaoManifestacao()
        {
            HistoricoManifestacao = new HashSet<HistoricoManifestacao>();
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdSituacaoManifestacao { get; set; }
        public string DescSituacaoManifestacao { get; set; }

        public virtual ICollection<HistoricoManifestacao> HistoricoManifestacao { get; set; }
        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}