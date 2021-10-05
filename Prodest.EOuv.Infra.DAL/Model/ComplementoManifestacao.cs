using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ComplementoManifestacao
    {
        public int IdComplemento { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtComplemento { get; set; }
        public DateTime? DtComplemento { get; set; }
        public DateTime? DtLeitura { get; set; }
        public int? IdUsuarioLeitura { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Usuario UsuarioLeitura { get; set; }
    }
}