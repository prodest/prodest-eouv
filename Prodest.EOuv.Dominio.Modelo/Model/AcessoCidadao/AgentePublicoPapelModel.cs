using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class AgentePublicoPapelModel
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string LotacaoGuid { get; set; }
        public UnidadeModel Lotacao { get; set; }
        public string AgentePublicoSub { get; set; }
        public string AgentePublicoNome { get; set; }
        public bool Prioritario { get; set; }
        public PerfilModel[] Perfis { get; set; }
    }
}
