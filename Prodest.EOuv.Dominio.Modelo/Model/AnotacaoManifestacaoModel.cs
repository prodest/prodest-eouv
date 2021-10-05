using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class AnotacaoManifestacaoModel
    {
        public int IdAnotacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtAnotacao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAnotacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}