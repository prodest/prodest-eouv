using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Log
    {
        public int IdLog { get; set; }
        public int? IdUsuario { get; set; }
        public string DescLog { get; set; }
        public DateTime DataHora { get; set; }
        public int? IdItemInterface { get; set; }
    }
}