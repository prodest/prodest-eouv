using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class DocumentoModel
    {
        public string Id { get; set; }
        public string Registro { get; set; }
        public string Url { get; set; }
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public string Base64 { get; set; }
        public Enums.nivelAcesso nivelAcesso { get; set; }
    }
}