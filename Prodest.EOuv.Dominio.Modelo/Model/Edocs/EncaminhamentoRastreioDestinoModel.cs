using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class EncaminhamentoRastreioDestinoModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int TipoAgente { get; set; }
        public string DescricaoTipoAgente { get; set; }
    }
}