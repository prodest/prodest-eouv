using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class FundamentoLegalModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }
        public string NivelAcesso { get; set; }
    }
}
