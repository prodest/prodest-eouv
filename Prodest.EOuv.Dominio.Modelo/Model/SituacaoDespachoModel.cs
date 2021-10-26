using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class SituacaoDespachoModel
    {
        public SituacaoDespachoModel()
        {
            DespachoManifestacao = new HashSet<DespachoManifestacaoModel>();
        }

        public int IdSituacaoDespacho { get; set; }
        public string DescSituacaoDespacho { get; set; }

        public virtual ICollection<DespachoManifestacaoModel> DespachoManifestacao { get; set; }
    }
}