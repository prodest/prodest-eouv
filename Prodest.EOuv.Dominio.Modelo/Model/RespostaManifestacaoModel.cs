using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class RespostaManifestacaoModel
    {
        public int IdRespostaManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtResposta { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataResposta { get; set; }
        public DateTime? PrazoResposta { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel Orgao { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}