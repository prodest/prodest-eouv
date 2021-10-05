using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ArquivamentoManifestacaoModel
    {
        public int IdArquivamentoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtJustificativaArquivamento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataArquivamento { get; set; }

        public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}