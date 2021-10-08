using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class ConjuntoGrupoModel
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string ConjuntoPai { get; set; }
        public string TipoNome { get; set; }
        public int TipoId { get; set; }
    }
}
