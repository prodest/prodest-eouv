using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ProcessoDesentranharResponseModel
    {
        public string Id { get; set; }
        public DateTime DataHora { get; set; }
        public string IdTermo { get; set; }
        public string RegistroTermo { get; set; }
        public string Justificativa { get; set; }
        public DocumentoDesentranhadoModel[] DocumentosDesentranhados { get; set; }
        public int Tipo { get; set; }
    }
}