using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class RespostaManifestacao
    {
        public int IdRespostaManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtResposta { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataResposta { get; set; }
        public DateTime? PrazoResposta { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}