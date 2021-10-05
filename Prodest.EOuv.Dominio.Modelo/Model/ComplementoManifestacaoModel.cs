using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ComplementoManifestacaoModel
    {
        public int IdComplemento { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtComplemento { get; set; }
        public DateTime? DtComplemento { get; set; }
        public DateTime? DtLeitura { get; set; }
        public int? IdUsuarioLeitura { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual UsuarioModel UsuarioLeitura { get; set; }
    }
}