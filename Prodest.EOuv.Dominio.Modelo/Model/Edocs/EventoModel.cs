using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class EventoModel
    {
        public string Id { get; set; }
        public string IdCidadao { get; set; }
        public string Situacao { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Conclusao { get; set; }
        public string Tipo { get; set; }
        public string IdProcesso { get; set; }
        public string IdAto { get; set; }
        public string IdTermo { get; set; }
        public string IdEncaminhamento { get; set; }
        public string IdDocumento { get; set; }
    }
}
