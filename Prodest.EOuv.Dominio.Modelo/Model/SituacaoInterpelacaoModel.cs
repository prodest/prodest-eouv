using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class SituacaoInterpelacaoModel
    {
        public SituacaoInterpelacaoModel()
        {
            InterpelacaoManifestacao = new HashSet<InterpelacaoManifestacaoModel>();
        }

        public int IdSituacaoInterpelacao { get; set; }
        public string DescSituacaoInterpelacao { get; set; }

        public virtual ICollection<InterpelacaoManifestacaoModel> InterpelacaoManifestacao { get; set; }
    }
}