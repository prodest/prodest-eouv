using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class DespachoManifestacaoModel
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
        public int? IdAgenteDestinatario { get; set; }
        public int? IdAgenteResposta { get; set; }
        public DateTime? DataRespostaDespacho { get; set; }
        public string Situacao { get; set; }

        public virtual OrgaoModel Orgao { get; set; }
        public virtual UsuarioModel UsuarioSolicitacaoDespacho { get; set; }
        public virtual AgenteManifestacaoModel AgenteDestinatario { get; set; }
        public virtual AgenteManifestacaoModel AgenteResposta { get; set; }
    }
}