using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class ClasseModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
    }
}