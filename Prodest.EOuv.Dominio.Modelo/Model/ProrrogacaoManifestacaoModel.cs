using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ProrrogacaoManifestacaoModel
    {
        public int IdProrrogacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtJustificativaProrrogacao { get; set; }
        public DateTime PrazoOriginal { get; set; }
        public DateTime NovoPrazo { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataProrrogacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel Orgao { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}