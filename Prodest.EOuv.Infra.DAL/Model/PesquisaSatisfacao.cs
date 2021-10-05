using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class PesquisaSatisfacao
    {
        public int IdPesquisaSatisfacao { get; set; }
        public int? IdManifestacao { get; set; }
        public short NotaAvaliacao { get; set; }
        public string TxtAvaliacao { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
    }
}