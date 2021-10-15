using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class EncaminhamentoRastreioModel
    {
        public string Id { get; set; }
        public string IdentificadorExterno { get; set; }
        public string Assunto { get; set; }
        public DateTime DataHora { get; set; }
        public EncaminhamentoRastreioDestinoModel Responsavel { get; set; }
        public EncaminhamentoRastreioDestinoModel[] Destinos { get; set; }
        public string IdEncaminhamentoAnterior { get; set; }
        public string IdEncaminhamentoInicial { get; set; }
        public string IdResponsavel { get; set; }
        public DocumentoControladoModel[] Documentos { get; set; }
        public EncaminhamentoRastreioModel[] EncaminhamentosPosteriores { get; set; }
    }
}