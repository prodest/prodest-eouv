using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class ProcessoEntranharModel
    {
        public string Id { get; set; }
        public DateTime DataHora { get; set; }
        public string IdTermo { get; set; }
        public string RegistroTermo { get; set; }
        public string Justificativa { get; set; }
        public int Tipo { get; set; } = 1;
        public bool IsSolicitacaoEntranhamento { get; set; }
        public string IdTermoEntranhamento { get; set; }
        public string RegistroTermoEntranhamento { get; set; }
    }
}
