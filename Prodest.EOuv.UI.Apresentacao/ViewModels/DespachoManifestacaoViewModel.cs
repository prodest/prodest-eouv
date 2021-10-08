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
        public string DataSolicitacaoDespacho { get; set; }
        public string PrazoResposta { get; set; }
        public string ProtocoloEdocs { get; set; }
        public Guid? IdEncaminhamento { get; set; }
        public Guid? GuidUsuarioDestinatarioEdocs { get; set; }
        public string NomeUsuarioDestinatarioEdocs { get; set; }
        public Guid? GuidSetorDestinatarioEdocs { get; set; }
        public string NomeSetorDestinatarioEdocs { get; set; }
        public string SiglaSetorDestinatarioEdocs { get; set; }
        public string DataRespostaDespacho { get; set; }
        public Guid? GuidUsuarioRespostaEdocs { get; set; }
        public string NomeUsuarioRespostaEdocs { get; set; }
        public Guid? GuidSetorRespostaEdocs { get; set; }
        public string NomeSetorRespostaEdocs { get; set; }
        public string SiglaSetorRespostaEdocs { get; set; }

        [Display(Name = "Situação")]
        public string Situacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        //public virtual OrgaoModel Orgao { get; set; }
        //public virtual SetorModel SetorDestino { get; set; }
        //public virtual SetorModel SetorOrigem { get; set; }
        //public virtual UsuarioModel UsuarioRespostaDespacho { get; set; }
        //public virtual UsuarioModel UsuarioSolicitacaoDespacho { get; set; }
    }
}