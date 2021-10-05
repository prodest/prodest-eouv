using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class NotificacaoManifestacaoModel
    {
        public int IdNotificacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtNotificacao { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataNotificacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel Orgao { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}