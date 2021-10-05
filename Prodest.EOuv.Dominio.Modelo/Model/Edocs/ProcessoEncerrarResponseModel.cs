using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class ProcessoEncerrarResponseModel
    {
        public string Id { get; set; }
        public DateTime DataHora { get; set; }
        public string IdTermo { get; set; }
        public string RegistroTermo { get; set; }
        public string Desfecho { get; set; }
        public int Tipo { get; set; }
    }
}
