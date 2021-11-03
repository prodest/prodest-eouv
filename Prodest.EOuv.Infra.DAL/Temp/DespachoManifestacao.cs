﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL.Temp
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
        public int? IdAgenteDestinatario { get; set; }
        public int? IdAgenteResposta { get; set; }
        public DateTime? DataRespostaDespacho { get; set; }
        public int? IdSituacaoDespacho { get; set; }

        public virtual AgenteManifestacao IdAgenteDestinatarioNavigation { get; set; }
        public virtual AgenteManifestacao IdAgenteRespostaNavigation { get; set; }
    }
}