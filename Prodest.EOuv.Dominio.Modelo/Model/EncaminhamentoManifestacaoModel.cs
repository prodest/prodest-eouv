using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class EncaminhamentoManifestacaoModel
    {
        public int IdEncaminhamentoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int IdOrgaoOrigem { get; set; }
        public int IdOrgaoDestino { get; set; }
        public string TxtEncaminhamento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataEncaminhamento { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel OrgaoDestino { get; set; }

        public virtual OrgaoModel OrgaoOrigem { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}