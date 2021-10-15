using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class EncaminhamentoModel
    {
        public string UrlHistorico { get; set; }
        public string IdentificadorExterno { get; set; }
        public string Id { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
        public string Protocolo { get; set; }
        public string UrlDocumentoEdocs { get; set; }
        public LocalModel Origem { get; set; }
        public LocalModel[] Destinos { get; set; }
        public DocumentoEncaminhamentoModel[] DocumentosEncaminhamento { get; set; }
    }
}