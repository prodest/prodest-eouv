using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class GerarUrlModel
    {
        public string Url { get; set; }
        public string IdentificadorTemporarioArquivoNaNuvem { get; set; }
        public Dictionary<string, string> Body { get; set; }
    }
}