using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class LogModel
    {
        public int IdLog { get; set; }
        public int? IdUsuario { get; set; }
        public string DescLog { get; set; }
        public DateTime DataHora { get; set; }
        public int? IdItemInterface { get; set; }
    }
}