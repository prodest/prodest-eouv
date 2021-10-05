using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class AnexoManifestacaoModel
    {
        public AnexoManifestacaoModel()
        {
            ArquivoFisicoAnexoManifestacao = new HashSet<ArquivoFisicoAnexoManifestacaoModel>();
        }

        public int IdAnexoManifestacao { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DatPostagem { get; set; }
        public int IdManifestacao { get; set; }
        public int? IdObjeto { get; set; }
        public int IdTipoAnexoManifestacao { get; set; }
        public bool? Ativo { get; set; }

        public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual TipoAnexoManifestacaoModel TipoAnexoManifestacao { get; set; }
        public virtual ICollection<ArquivoFisicoAnexoManifestacaoModel> ArquivoFisicoAnexoManifestacao { get; set; }
    }
}