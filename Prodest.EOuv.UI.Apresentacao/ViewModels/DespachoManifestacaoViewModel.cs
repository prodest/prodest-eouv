using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prodest.EOuv.UI.Apresentacao
{
    public partial class DespachoManifestacaoViewModel
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

        [Display(Name = "Situação")]
        public string Situacao { get; set; }
    }
}