using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class FeriadoModel
    {
        public int IdFeriado { get; set; }
        public DateTime? DatFeriado { get; set; }
        public string DescFeriado { get; set; }
    }
}