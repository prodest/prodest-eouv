using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class LogAcesso
    {
        public int IdLogAcesso { get; set; }
        public int IdUsuario { get; set; }
        public int? IdOrgao { get; set; }
        public DateTime DataAcesso { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}