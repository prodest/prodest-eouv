using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class DocumentoRequestModel
    {
        // v1
        public string AssinanteId { get; set; }

        public string DocumentoClasseId { get; set; }
        public string FileName { get; set; }
        public bool Publico { get; set; }
        public Guid[] FundamentosLegaisIds { get; set; }
        public byte[] Data { get; set; }

        // v2
        public string IdPapelCapturadorAssinante { get; set; }

        public string IdPapelCapturador { get; set; }
        public string IdClasse { get; set; }
        public Enums.DocumentoValorLegal ValorLegalDocumentoConferencia { get; set; }
        public Enums.DocumentoValorLegal ValorLegal { get; set; }
        public string NomeArquivo { get; set; }
        public bool CredenciarCapturador { get; set; }
        public RestricaoAcessoModel RestricaoAcesso { get; set; }
        public string IdentificadorTemporarioArquivoNaNuvem { get; set; }
    }
}