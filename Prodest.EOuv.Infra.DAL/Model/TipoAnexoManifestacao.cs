using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class TipoAnexoManifestacao
    {
        public TipoAnexoManifestacao()
        {
            AnexoManifestacao = new HashSet<AnexoManifestacao>();
        }

        public int IdTipoAnexoManifestacao { get; set; }
        public string DescTipoAnexoManifestacao { get; set; }

        public virtual ICollection<AnexoManifestacao> AnexoManifestacao { get; set; }
    }
}