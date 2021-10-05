using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class TipoAnexoManifestacaoModel
    {
        public TipoAnexoManifestacaoModel()
        {
            AnexoManifestacao = new HashSet<AnexoManifestacaoModel>();
        }

        public int IdTipoAnexoManifestacao { get; set; }
        public string DescTipoAnexoManifestacao { get; set; }

        public virtual ICollection<AnexoManifestacaoModel> AnexoManifestacao { get; set; }
    }
}