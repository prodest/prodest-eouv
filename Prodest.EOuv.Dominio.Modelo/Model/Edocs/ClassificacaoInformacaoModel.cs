using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class ClassificacaoInformacaoModel
    {
        public long PrazoAnos { get; set; }
        public long PrazoMeses { get; set; }
        public long PrazoDias { get; set; }
        public string Justificativa { get; set; }
        public string IdPapelAprovador { get; set; }
    }
}
