using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class RecursoModel
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public AcaoModel[] Acoes { get; set; }
    }
}
