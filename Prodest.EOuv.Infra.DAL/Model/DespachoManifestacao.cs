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
        public Guid? GuidUsuarioDestinatarioEdocs { get; set; }
        public string NomeUsuarioDestinatarioEdocs { get; set; }
        public Guid? GuidSetorDestinatarioEdocs { get; set; }
        public string NomeSetorDestinatarioEdocs { get; set; }
        public string SiglaSetorDestinatarioEdocs { get; set; }
        public DateTime? DataRespostaDespacho { get; set; }
        public Guid? GuidUsuarioRespostaEdocs { get; set; }
        public string NomeUsuarioRespostaEdocs { get; set; }
        public Guid? GuidSetorRespostaEdocs { get; set; }
        public string NomeSetorRespostaEdocs { get; set; }
        public string SiglaSetorRespostaEdocs { get; set; }
        public string Situacao { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao Orgao { get; set; }
        public virtual Usuario UsuarioSolicitacaoDespacho { get; set; }
    }
}