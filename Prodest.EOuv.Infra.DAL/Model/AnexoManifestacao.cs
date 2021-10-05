using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class AnexoManifestacao
    {
        public AnexoManifestacao()
        {
            ArquivoFisicoAnexoManifestacao = new HashSet<ArquivoFisicoAnexoManifestacao>();
        }

        public int IdAnexoManifestacao { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DatPostagem { get; set; }
        public int IdManifestacao { get; set; }
        public int? IdObjeto { get; set; }
        public int IdTipoAnexoManifestacao { get; set; }
        public bool? Ativo { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual TipoAnexoManifestacao TipoAnexoManifestacao { get; set; }
        public virtual ICollection<ArquivoFisicoAnexoManifestacao> ArquivoFisicoAnexoManifestacao { get; set; }
    }
}