using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class PesquisaSatisfacaoModel
    {
        public int IdPesquisaSatisfacao { get; set; }
        public int? IdManifestacao { get; set; }
        public short NotaAvaliacao { get; set; }
        public string TxtAvaliacao { get; set; }
        public DateTime DataAvaliacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
    }
}