using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class DespachoManifestacao
    {
        public int IdDespachoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int IdOrgao { get; set; }
        public string TextoSolicitacaoDespacho { get; set; }
        public int IdUsuarioSolicitacaoDespacho { get; set; }
        public DateTime DataSolicitacaoDespacho { get; set; }
        public DateTime PrazoResposta { get; set; }
        public string ProtocoloEdocs { get; set; }
        public Guid? IdEncaminhamento { get; set; }
        public int IdAgenteDestinatario { get; set; }
        public int IdAgenteResposta { get; set; }
        public DateTime? DataRespostaDespacho { get; set; }
        public string Situacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario UsuarioSolicitacaoDespacho { get; set; }
        public virtual AgenteManifestacao AgenteDestinatario { get; set; }
        public virtual AgenteManifestacao AgenteResposta { get; set; }
    }
}