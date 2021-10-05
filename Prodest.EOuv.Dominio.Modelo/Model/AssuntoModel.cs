using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class AssuntoModel
    {
        public int IdAssunto { get; set; }
        public string DescAssunto { get; set; }
        public bool IndAssuntoGeral { get; set; }
        public bool? IndAssuntoSic { get; set; }
        public string Observacao { get; set; }
    }
}