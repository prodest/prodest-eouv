using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class SituacaoInterpelacao
    {
        public SituacaoInterpelacao()
        {
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacao>();
        }

        public int IdSituacaoInterpelacao { get; set; }
        public string DescSituacaoInterpelacao { get; set; }

        public virtual ICollection<InterpelacaoManifestacao> InterpelacaoManifestacao { get; set; }
    }
}