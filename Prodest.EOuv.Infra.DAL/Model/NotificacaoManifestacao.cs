using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class NotificacaoManifestacao
    {
        public int IdNotificacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtNotificacao { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataNotificacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}