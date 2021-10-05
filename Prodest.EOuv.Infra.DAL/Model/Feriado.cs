using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Feriado
    {
        public int IdFeriado { get; set; }
        public DateTime? DatFeriado { get; set; }
        public string DescFeriado { get; set; }
    }
}