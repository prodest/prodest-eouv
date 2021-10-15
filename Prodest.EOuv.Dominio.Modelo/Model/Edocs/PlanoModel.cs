using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class PlanoModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public List<ClasseModel> Classes { get; set; }
    }
}