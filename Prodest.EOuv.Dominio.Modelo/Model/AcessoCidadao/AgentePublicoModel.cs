using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{ 
    public class AgentePublicoModel
    {
        public string Sub { get; set; }
        public int SubDescontinuado { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
    }
}
